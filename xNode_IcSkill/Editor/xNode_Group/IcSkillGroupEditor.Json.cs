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
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
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
         private void _saveAsJson()
        {
            var path = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, target.name, "Json");
            
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            
            Dictionary<string,object> map = new Dictionary<string, object>();
            
            Dictionary<Type,int> nodeTypeRefMap = new Dictionary<Type, int>();
            List<string> nodeTypes = new List<string>();
            map.Add("NodeTypes", nodeTypes);
            
            var ports = new List<string>();
            map.Add("NodePorts", ports);

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
            
            var nodes = new List<Dictionary<string,object>>();
            map.Add("Nodes",nodes);
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
                
                nMap.Add("Type", nodeTypeRefMap[type]);

                if (node.name != NodeEditorUtilities.NodeDefaultName(type))
                {
                    nMap.Add("Name", node.name);
                }
                
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

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
                        var assetPath = Setting.AssetProcessorType.GetPath((Object) value);
                        
                        nMap.Add(field.Name,assetPath);
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
                nMap.Add("Ports",portsMap);
                
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

            var json = JsonConvert.SerializeObject(map, new UnityValueTypeConverter());
            
            File.WriteAllText(path,json);

            if (path.IndexOf(Application.dataPath, StringComparison.Ordinal) != -1)
            {
                AssetDatabase.Refresh();
            }
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
            
            IcSkillGraph graph = ScriptableObject.CreateInstance<IcSkillGraph>();

            AssetDatabase.CreateAsset(graph, saveFilePath.Replace(Application.dataPath, "Assets"));
            
            var nodeTypes = (map["NodeTypes"] as JArray).Values<string>().ToArray();
            var nodesJ = (map["Nodes"] as JArray);
            Dictionary<string, object>[] nodes = nodesJ.ToObject<Dictionary<string, object>[]>();
            var nodePorts = (map["NodePorts"] as JArray).Values<string>().ToArray();

            var ser = JsonSerializer.CreateDefault();
            ser.Converters.Add(new UnityValueTypeConverter());
            foreach (var nodeMap in nodes)
            {
                var type = nodeTypes[(long) nodeMap["Type"]];
                var nodeType = Type.GetType(type);
                var node = graph.AddNode(nodeType);
                
                if (!nodeMap.TryGetValue("Name",out var na))
                {
                    na = NodeEditorUtilities.NodeDefaultName(nodeType);
                }
                node.name = na.ToString();
                
                AssetDatabase.AddObjectToAsset(node, graph);
                foreach (var field in nodeMap)
                {
                    if (field.Key == "Ports" || field.Key == "Type" || field.Key == "Name")
                    {
                        continue;
                    }

                    var fieldInfo = nodeType.GetField(field.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

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
                    
                    fieldInfo.SetValue(node,field.Value);
                }
            }

            //All Node port
            {
                int index = 0;
                foreach (var nodeMap in nodes)
                {
                    var node = graph.nodes[index];
                   
                    if (nodeMap.TryGetValue("Ports", out var result))
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
            }
            
            
            AssetDatabase.Refresh();
        }
    }
}