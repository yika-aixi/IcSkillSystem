//Create: Icarus
//ヾ(•ω•`)o
//2020-08-02 11:50
//CabinIcarus.IcSkillSystem.xNodeIc.Editor

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CabinIcarus.EditorFrame.Expansion.NewtonsoftJson;
using CabinIcarus.IcFrameWork.IcSkillSystem.SkillSystem.Scripts.Runtime.Utils;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    public partial class IcSkillGroupEditor
    {
        private const string JsonVerKey = "Ver";
        private const string NodeTypesKey = "NodeTypes";
        private const string NodePortsKey = "NodePorts";
        private const string NodesKey = "Nodes";
        private const string UnityObjectsKey = "UnityObjects";
        private const string TypeKey = "Type";
        private const string NameKey = "Name";
        private const string PortsKey = "Ports";
        private const string GraphVarsKey = "GraphVars";
        private const string GraphVarTypesKey = "GraphVarTypes";
        private const char GraphVarsUnityObjectTag = '&';
        private const string JsonVer = "2.1";
        private void _saveAsJson()
        {
            var path = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, target.name, "Json");

            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            
            _saveAsJson(path);
            
            if (path.IndexOf(Application.dataPath, StringComparison.Ordinal) != -1)
            {
                AssetDatabase.Refresh();
            }
            
            InternalOpenFolder(Path.GetDirectoryName(path));
        }
        
        private void _saveAsJson(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            FieldInfo[] fields;

            Dictionary<string,object> map = new Dictionary<string, object>();
            
            map.Add(JsonVerKey,JsonVer);
            
            Dictionary<Type,int> nodeTypeRefMap = new Dictionary<Type, int>();
            List<string> nodeTypes = new List<string>();
            map.Add(NodeTypesKey, nodeTypes);
            
            var ports = new List<string>();
            map.Add(NodePortsKey, ports);

            foreach (var node in target.nodes)
            {
                foreach (var nodePort in node.Ports)
                {
                    if (ports.Contains(nodePort.fieldName))
                    {
                        continue;
                    }
         
                    ports.Add(nodePort.fieldName);
                }
            }
            
            Dictionary<Object, int> unityObjectRef = new Dictionary<Object, int>();
            List<string> unityObjects = null;
            var skG = (IcSkillGraph) target;

            {
                foreach (var node in target.nodes)
                {
                    var type = node.GetType();
                    
                    fields = type.GetTypeAllField();

                    var result = fields
                            .Where(x => x.GetCustomAttribute<NonSerializedAttribute>() == null)
                            .Where(x =>  x.IsPublic || x.IsPrivate && x.GetCustomAttribute<SerializeField>() != null)
                            .Where(x => x.Name != nameof(Node.graph) && x.Name != Node.PortFieldName &&
                                        x.Name != nameof(RootNode.OutValue))
                        ;

                    foreach (var field in result)
                    {
                        var value = field.GetValue(node);

                        if (typeof(Object).IsAssignableFrom(field.FieldType))
                        {
                            if (value == null || unityObjectRef.ContainsKey((Object) value))
                            {
                                continue;
                            }
                            
                            var assetPath = Setting.AssetProcessorType.GetPath((Object) value);

                            if (unityObjects == null)
                            {
                                unityObjects = new List<string>();
                                map.Add(UnityObjectsKey, unityObjects);
                            }
                            
                            unityObjects.Add(assetPath);
                            
                            unityObjectRef.Add((Object) value, unityObjects.Count -1);
                        }
                    }
                }
                
                foreach (var var in skG.VariableMap)
                {
                    if (var.Value.IsUValue)
                    {
                        var uValue = var.Value.GetUnityValue();
                        
                        if (uValue == null || unityObjectRef.ContainsKey(uValue))
                        {
                            continue;
                        }
                            
                        var assetPath = Setting.AssetProcessorType.GetPath(uValue);

                        if (unityObjects == null)
                        {
                            unityObjects = new List<string>();
                            map.Add(UnityObjectsKey, unityObjects);
                        }
                            
                        unityObjects.Add(assetPath);
                            
                        unityObjectRef.Add(uValue, unityObjects.Count -1);
                    }
                }
            }

            if (skG.VariableMap.Count > 0)
            {
                List<string> graphVarTypes = null;
                Dictionary<Type,int> gTypeCache = new Dictionary<Type, int>();
                
                foreach (var var in skG.VariableMap)
                {
                    var valueType = var.Value.ValueType;

                    if (valueType == null)
                    {
                        continue;
                    }

                    if (graphVarTypes == null)
                    {
                        graphVarTypes = new List<string>();
                        map.Add(GraphVarTypesKey, graphVarTypes);
                    }
                    
                    if (!graphVarTypes.Contains(valueType.AssemblyQualifiedName))
                    {
                        graphVarTypes.Add(valueType.AssemblyQualifiedName);
                        gTypeCache.Add(valueType,graphVarTypes.Count - 1);
                    }
                }

                if (graphVarTypes != null)
                {
                    Dictionary<string,object> graphVar = new Dictionary<string, object>();
                    map.Add(GraphVarsKey, graphVar);

                    foreach (var var in skG.VariableMap)
                    {
                        var valueType = var.Value.ValueType;

                        if (valueType == null)
                        {
                            continue;
                        }
                        
                        if (var.Value.IsUValue)
                        {
                            if (var.Value.GetUnityValue())
                            {
                                graphVar.Add(GraphVarsUnityObjectTag +var.Key, unityObjectRef[var.Value.GetUnityValue()]);
                            }
                        }
                        else
                        {
                            /*
                             * 0. Value type
                             * 1. Value
                             */
                            graphVar.Add(var.Key, new[]
                            {
                                gTypeCache[valueType]
                                ,
                                var.Value.GetValueInfo().GetValue()
                            });
                        }
                    }
                }
            }

            var nodes = new List<Dictionary<string,object>>();
            map.Add(NodesKey,nodes);
            Dictionary<Node,int> nodeRefMap = new Dictionary<Node, int>();

            foreach (var node in target.nodes)
            {
                var nMap = new Dictionary<string, object>();
                nodes.Add(nMap);
                nodeRefMap.Add(node, nodes.Count - 1);

                var type = node.GetType();
                
                if (nodeTypeRefMap.ContainsKey(type))
                {
                    continue;
                }
                
                nodeTypes.Add(node.GetType().AssemblyQualifiedName);
                
                nodeTypeRefMap.Add(type,nodeTypes.Count - 1);
            }
            
            foreach (var node in target.nodes)
            {
                var nMap = nodes[nodeRefMap[node]];
 
                var type = node.GetType();
                
                nMap.Add(TypeKey, nodeTypeRefMap[type]);

                if (node.name != NodeEditorUtilities.NodeDefaultName(type))
                {
                    nMap.Add(NameKey, node.name);
                }
                
                fields = type.GetTypeAllField();
                var result = fields
                    .Where(x => x.GetCustomAttribute<NonSerializedAttribute>() == null)
                    .Where(x=>  x.IsPublic || x.IsPrivate && x.GetCustomAttribute<SerializeField>() != null)
                    .Where(x=> x.Name != nameof(Node.graph) && x.Name != Node.PortFieldName && x.Name != nameof(RootNode.OutValue))
                    ;
                
                foreach (var field in result)
                {
                    var value = field.GetValue(node);
                    
                    if (typeof(Object).IsAssignableFrom(field.FieldType))
                    {
                        if (value == null)
                        {
                            continue;
                        }
                        
                        nMap.Add(field.Name, unityObjectRef[(Object) value]);
                    }
                    else
                    {
                        nMap.Add(field.Name, value);
                    }
                }

                if (!node.Ports.Any())
                {
                    continue;
                }
                
                //port
                Dictionary<string, Dictionary<string,object>> portsMap = new Dictionary<string, Dictionary<string, object>>();
                nMap.Add(PortsKey,portsMap);
                
                foreach (var nodePort in node.Ports)
                {
                    if (!nodePort.IsConnected)
                    {
                        continue;
                    }
                    
                    var portMap = new Dictionary<string,object>();
                    
                    portsMap.Add(ports.IndexOf(nodePort.fieldName).ToString(), portMap);
                        
                    /*
                     * 1. connect target node
                     * 2. connect target node port
                     */
                    var connects = new List<int>();
                        
                    portMap.Add(NodePort.ConnectionsEditor, connects);
                    for (var i = 0; i < nodePort.ConnectionCount; i++)
                    {
                        var connect = nodePort.GetConnection(i);
                        if (connect.IsConnected)
                        {
                            connects.Add(nodeRefMap[connect.node]);
                            connects.Add(ports.IndexOf(connect.fieldName));
                        }
                    }
                }
            }

            var ser = new JsonSerializerSettings();
            ser.Converters.Add(new UnityValueTypeConverter());
            ser.Converters.Add(new IcVariableConverter());
            
            var json = JsonConvert.SerializeObject(map,Formatting.None, ser);
            
            File.WriteAllText(filePath,json);
        }
        
        private void _readJson()
        {
            var jsonPath = EditorUtility.OpenFilePanel("Json Path", Application.dataPath,"Json");
            
            if (string.IsNullOrWhiteSpace(jsonPath))
            {
                return;
            }
            
            var saveFilePath = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, Path.GetFileNameWithoutExtension(jsonPath), "asset");
            
            if (string.IsNullOrWhiteSpace(saveFilePath))
            {
                return;
            }

            if (saveFilePath.IndexOf(Application.dataPath, StringComparison.Ordinal) == -1)
            {
                EditorUtility.DisplayDialog("Error", "graph asset save path need is project path", "ok");
                return;
            }

            var map = JsonConvert.DeserializeObject<Dictionary<string,object>>(File.ReadAllText(jsonPath), new UnityValueTypeConverter());

            if (map.TryGetValue(JsonVerKey,out var ver))
            {
                var verStr = ver.ToString();
                if (verStr != JsonVer || verStr != "2")
                {
                    EditorUtility.DisplayDialog("Error",
                        $"Json Version Does not match, the current version is {JsonVer}, and the read file version is {map[JsonVerKey]}","ok");
                    
                    return;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Error",
                    $"Unknown json","ok");
                return;
            }
            
            
            IcSkillGraph graph = ScriptableObject.CreateInstance<IcSkillGraph>();

            AssetDatabase.CreateAsset(graph, saveFilePath.Replace(Application.dataPath, "Assets"));
            
            var nodeTypes = (map[NodeTypesKey] as JArray).Values<string>().ToArray();
            var nodesJ = (map[NodesKey] as JArray);
            Dictionary<string, object>[] nodes = nodesJ.ToObject<Dictionary<string, object>[]>();
            var nodePorts = (map[NodePortsKey] as JArray).Values<string>().ToArray();

            string[] unityObjectPaths = null;

            if (map.TryGetValue(UnityObjectsKey, out var pathResults))
            {
                unityObjectPaths = (pathResults as JArray).Values<string>().ToArray();
            }

            var ser = JsonSerializer.CreateDefault();
            ser.Converters.Add(new UnityValueTypeConverter());
            ser.Converters.Add(new IcVariableConverter());
            
            foreach (var nodeMap in nodes)
            {
                var type = nodeTypes[(long) nodeMap[TypeKey]];
                var nodeType = Type.GetType(type);
                var node = graph.AddNode(nodeType);
                
                if (!nodeMap.TryGetValue(NameKey,out var na))
                {
                    na = NodeEditorUtilities.NodeDefaultName(nodeType);
                }
                node.name = na.ToString();
                
                AssetDatabase.AddObjectToAsset(node, graph);
                foreach (var field in nodeMap)
                {
                    if (field.Key == PortsKey || field.Key == TypeKey || field.Key == NameKey)
                    {
                        continue;
                    }


                    string fieldName = field.Key;
                    
                    var fieldInfo = nodeType.GetTypeField(fieldName);

                    if (fieldInfo.FieldType.IsEnum)
                    {
                        fieldInfo.SetValue(node, Enum.Parse(fieldInfo.FieldType,field.Value.ToString()));
                        continue;
                    }
                    
                    if (fieldInfo.FieldType.IsValueType)
                    {
                        if (field.Value is long lv)
                        {
                            fieldInfo.SetValue(node, Convert.ChangeType(lv, fieldInfo.FieldType));
                            continue;
                        }
                    
                        if (field.Value is double db)
                        {
                            fieldInfo.SetValue(node, Convert.ChangeType(db, fieldInfo.FieldType));
                            continue;
                        }
                    }

                    if (field.Value is JObject jObject)
                    {
                        fieldInfo.SetValue(node, jObject.ToObject(fieldInfo.FieldType, ser));
                        continue;
                    }

                    if (typeof(AValueInfo).IsAssignableFrom(fieldInfo.FieldType))
                    {
                        var v = (AValueInfo) Activator.CreateInstance(fieldInfo.FieldType);
                        v.SetValue(field.Value);
                        
                        fieldInfo.SetValue(node, v);
                        continue;
                    }

                    if (typeof(Object).IsAssignableFrom(fieldInfo.FieldType))
                    {
                        fieldInfo.SetValue(node, Setting.AssetProcessorType.GetAsset(unityObjectPaths[(long)field.Value]));
                        continue;
                    }
                    
                    fieldInfo.SetValue(node, field.Value);
                }
            }

            //All Node port
            {
                int index = 0;
                foreach (var nodeMap in nodes)
                {
                    var node = graph.nodes[index];
                   
                    if (nodeMap.TryGetValue(PortsKey, out var result))
                    {
                        var ports = (result as JObject).ToObject<Dictionary<string, Dictionary<string, object>>>();

                        foreach (var portMap in ports)
                        {
                            var port = node.GetPort(nodePorts[long.Parse(portMap.Key)]);

                            /*
                             * 1. connect target node
                             * 2. connect target node port
                             */
                            var connects = (portMap.Value[NodePort.ConnectionsEditor] as JArray).Values<long>().ToArray();

                            var targetNode =  graph.nodes[(int) connects[0]];

                            var targetNodePort = targetNode.GetPort(nodePorts[connects[1]]);
                            
                            port.Connect(targetNodePort);
                        }
                    }

                    index++;
                }
                
                Dictionary<string, object> graphVars;

                if (map.TryGetValue(GraphVarsKey,out var vars))
                {
                    string[] gTypes = (map[GraphVarTypesKey] as JArray).ToObject<string[]>();
                    
                    graphVars = (vars as JObject).ToObject<Dictionary<string, object>>();
                    
                    foreach (var graphVar in graphVars)
                    {
                        if (graphVar.Key[0] == GraphVarsUnityObjectTag)
                        {
                            var objectPath = unityObjectPaths[(long)graphVar.Value];
                            graph.SetOrAddVariable(graphVar.Key.Remove(0,1),Setting.AssetProcessorType.GetAsset(objectPath));
                        }
                        else
                        {
                            var type = Type.GetType(gTypes[(graphVar.Value as JArray)[0].Value<long>()]);
                            
                            graph.SetOrAddVariable(graphVar.Key, (graphVar.Value as JArray)[1].ToObject(type));
                        }
                    }
                }
            }
            
            AssetDatabase.Refresh();
        }
    }
}