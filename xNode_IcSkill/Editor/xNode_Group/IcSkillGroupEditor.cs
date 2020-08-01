//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:41
//Assembly-CSharp

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using CabinIcarus.EditorFrame.Expansion.NewtonsoftJson;
using CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using XNode;
using XNodeEditor;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomNodeGraphEditor(typeof(IcSkillGraph),"CabinIcarus.IcSkillSystem")]
    public class IcSkillGroupEditor:NodeGraphEditor
    {
        public static event Func<NodeGraph,Type,bool> OnAllowCreate; 
        
        private string _noInputNPBehaveNode = "No Input NPBehave Node";
        
        public override string GetNodeMenuName(Type type)
        {
            if (!OnAllowCreate?.Invoke(target,type) ?? false)
            {
                return null;
            }
            
            return typeof(IIcSkillSystemNode).IsAssignableFrom(type) || type.FullName == "XNode.NodeGroups.NodeGroup" ? base.GetNodeMenuName(type) : null;
        }

        public override NodeEditorPreferences.Settings GetDefaultPreferences()
        {
            var settings = base.GetDefaultPreferences();
            
            settings.typeColors.Add(_noInputNPBehaveNode,Color.yellow);
            
            return settings;
        }

        public override void OnOpen()
        {
            base.OnOpen();

            if (_toolbarMenu == null)
            {
                _toolbarMenu = new GenericMenu();
            }
            
            AddMenuItem(new GUIContent("Save as/Json"), false, _saveAsJson);
            // AddMenuItem(new GUIContent("Save as/Binary"), false, _saveAsBinary);
            AddMenuItem(new GUIContent("Read/Json"), false, _readJson);
        }

        private GenericMenu _toolbarMenu;
        private Rect _last;
        public override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar,GUILayout.Width(window.position.width));
            {
                var menu = new GUIContent("Menu");
                var size = EditorStyles.toolbarButton.CalcSize(menu);
                if (GUILayout.Button(menu, EditorStyles.toolbarButton,GUILayout.Width(size.x)))
                {
                    _last.position += new Vector2(0,20);
                    _toolbarMenu.DropDown(_last);
                }

                _last = GUILayoutUtility.GetLastRect();
            }
            EditorGUILayout.EndHorizontal();
        }

        public void AddMenuItem(GUIContent content, bool on, Action clickCallback)
        {
            _toolbarMenu.AddItem(content, on, clickCallback.Invoke);
        }
        
        public void AddMenuItem(GUIContent content, bool on,object userData, Action<object> clickCallback)
        {
            _toolbarMenu.AddItem(content, on, clickCallback.Invoke,userData);
        }

        private void _saveAsJson()
        {
            var path = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, target.name, "Json");
            
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            
            Dictionary<string,object> map = new Dictionary<string, object>();

            map.Add("Type", target.GetType().AssemblyQualifiedName);
            map.Add("Name", target.name);
            
            var nodes = new List<Dictionary<string,object>>();
            map.Add("Nodes",nodes);
            Dictionary<Node,int> _nodeRefMap = new Dictionary<Node, int>();

            foreach (var node in target.nodes)
            {
                var nMap = new Dictionary<string, object>();
                nodes.Add(nMap);
                _nodeRefMap.Add(node, nodes.Count - 1);
            }
            
            var ports = new List<Dictionary<string,object>>();
            map.Add("NodePorts", ports);
            Dictionary<NodePort,int> _nodePortRefMap = new Dictionary<NodePort, int>();

            foreach (var node in target.nodes)
            {
                foreach (var nodePort in node.Ports)
                {
                    var portMap = new Dictionary<string,object>();
                    ports.Add(portMap);
                    _nodePortRefMap.Add(nodePort, ports.Count -1);
                    
                    var fields = nodePort.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    
                    var result = fields
                            .Where(x => x.GetCustomAttribute<NonSerializedAttribute>() == null)
                            .Where(x=>  x.IsPublic || x.IsPrivate && x.GetCustomAttribute<SerializeField>() != null)
                            .Where(x=> x.Name != NodePort.ConnectionsEditor)
                        ;
                    
                    foreach (var field in result)
                    {
                        var value = field.GetValue(nodePort);
                        
                        if (typeof(Node).IsAssignableFrom(field.FieldType))
                        {
                            portMap.Add(field.Name, _nodeRefMap[(Node) value]);                          
                        }
                        else
                        {
                            portMap.Add(field.Name, value);
                        }
                    }
                }
            }

            foreach (var node in target.nodes)
            {
                var nMap = nodes[_nodeRefMap[node]];
 
                var type = node.GetType();
                
                nMap.Add("Type", type.AssemblyQualifiedName);

                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                var result = fields
                    .Where(x => x.GetCustomAttribute<NonSerializedAttribute>() == null)
                    .Where(x=>  x.IsPublic || x.IsPrivate && x.GetCustomAttribute<SerializeField>() != null)
                    .Where(x=> x.Name != nameof(Node.graph) && x.Name != Node.PortFieldName)
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
                
                //port
                Dictionary<string, Dictionary<string,object>> portsMap = new Dictionary<string, Dictionary<string, object>>();
                nMap.Add("Ports",portsMap);
                
                foreach (var nodePort in node.Ports)
                {
                    var portMap = new Dictionary<string,object>();
                    
                    portsMap.Add(nodePort.fieldName,portMap);
                    
                    portMap.Add("Port", _nodePortRefMap[nodePort]);
                    
                    var connects = new List<int>();
                    
                    portMap.Add(NodePort.ConnectionsEditor, connects);
                    
                    for (var i = 0; i < nodePort.ConnectionCount; i++)
                    {
                        var connect = nodePort.GetConnection(i);
                        connects.Add(_nodePortRefMap[connect]);
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
        
        private void _saveAsBinary()
        {
            var path = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, target.name, "bin");
        }

        private void _readJson()
        {
            
        }

        //todo 先用它的这样的写法吧,后续改为在Node自定义编辑中处理
        public override string GetPortTooltip(NodePort port)
        {
            var tooltip = base.GetPortTooltip(port);

            var node = port.node;
            
            var attrs = node.GetType().GetField(port.fieldName,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetCustomAttributes(typeof(APortTooltipAttribute), false);

            if (attrs == null || attrs.Length == 0)
            {
                attrs = node.GetType().GetProperty(port.fieldName,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetCustomAttributes(typeof(APortTooltipAttribute), false);
            }
            
            if (attrs != null && attrs.Length == 1)
            {
                if (attrs[0] is PortTooltipAttribute tooltipAttribute)
                {
                    tooltip = string.IsNullOrEmpty(tooltipAttribute.Tooltip) ? tooltip : tooltipAttribute.Tooltip;
                }

                if (attrs[0] is PortTooltipMethodOrPropertyGetAttribute tooltipAttribute1)
                {
                    var method = node.GetType().GetMethod(tooltipAttribute1.MethodOrPropertyName,BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (method != null)
                    {
                        if (method.ReturnType != typeof(string))
                        {
                            throw new ArgumentException($"{tooltipAttribute1.MethodOrPropertyName} Method return type need is {typeof(string)}");
                        }

                        tooltip = (string) method.Invoke(node,null);
                    }
                    else
                    {
                        var property = node.GetType().GetProperty(tooltipAttribute1.MethodOrPropertyName,BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                        if (property != null)
                        {
                            if (property.PropertyType != typeof(string))
                            {
                                throw new ArgumentException($"{tooltipAttribute1.MethodOrPropertyName} Property type need is {typeof(string)}");
                            }

                            tooltip = (string) property.GetValue(node);
                        }
                    } 
                }
            }

            return tooltip;
        }
        
#if UNITY_2019_1_OR_NEWER
        [SettingsProvider]
        public static SettingsProvider CreateXNodeSettingsProvider() {
            SettingsProvider provider = new SettingsProvider("Preferences/Ic Skill System", SettingsScope.User) {
                guiHandler = PreferencesGUI,
                keywords = new HashSet<string>(new [] { "xNode", "node", "editor", "graph", "connections", "noodles", "ports", "Skill", "System" ,"Ic"})
            };
            return provider;
        }
#endif

        private static string[] _assetProcessorAqNames;
        private static string[] _assetProcessorNames;
        [InitializeOnLoadMethod]
        static void _initAQName()
        {
            var temp = TypeUtil.AllTypes
                .Where(x => typeof(ISaveAsAssetProcessor).IsAssignableFrom(x))
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsInterface);
Debug.LogError(temp.Count());
            var count = temp.Count();
            _assetProcessorAqNames = new string[count];
            _assetProcessorNames = new string[count];

            int i = 0;
            foreach (var type in temp)
            {
                _assetProcessorAqNames[i] = type.AssemblyQualifiedName;
                _assetProcessorNames[i] = type.FullName;
                i++;
            }
            
        }

        [Serializable]
        public class IcSkillSystemSetting
        {
            private const string SettingKey = "IcSkillSystem.Setting";

            [SerializeField]
            internal string processorAqName;
            
            private ISaveAsAssetProcessor _processor;
            public ISaveAsAssetProcessor AssetProcessorType
            {
                get
                {
                    if (_processor == null)
                    {
                        Type t = Type.GetType(processorAqName);

                        _processor = (ISaveAsAssetProcessor) Activator.CreateInstance(t);
                    }

                    return _processor;
                }
            }

            private IcSkillSystemSetting()
            {
            }

            public void Save()
            {
                EditorPrefs.SetString(SettingKey, JsonUtility.ToJson(this));
            }

            public static IcSkillSystemSetting Load()
            {
                var json = EditorPrefs.GetString(SettingKey);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new IcSkillSystemSetting()
                    {
                        processorAqName = typeof(DefaultSaveAsAssetProcessor).AssemblyQualifiedName
                    };
                }

                return JsonUtility.FromJson<IcSkillSystemSetting>(json);
            }
        }

        private static IcSkillSystemSetting _setting;
        public static IcSkillSystemSetting Setting
        {
            get { return _setting ??= IcSkillSystemSetting.Load(); }
        }

#if !UNITY_2019_1_OR_NEWER
        [PreferenceItem("Ic Skill System")]
#endif
        private static void PreferencesGUI(string obj)
        {
            int index = -1;

            for (var i = 0; i < _assetProcessorAqNames.Length; i++)
            {
                var processorAqName = _assetProcessorAqNames[i];

                if (processorAqName == Setting.processorAqName)
                {
                    index = i;
                    break;
                }
            }

            EditorGUI.BeginChangeCheck();
            {
                index = EditorGUILayout.Popup("Asset Processor", index, _assetProcessorNames);
            }
            if (EditorGUI.EndChangeCheck())
            {
                Setting.processorAqName = _assetProcessorAqNames[index];
                Setting.Save();
            }
        }
    }
}