//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:41
//Assembly-CSharp

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomNodeGraphEditor(typeof(IcSkillGraph),"CabinIcarus.IcSkillSystem")]
    public partial class IcSkillGroupEditor:NodeGraphEditor
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

        public override void OnCreate()
        {
            base.OnCreate();
            
            if (_fileMenu == null)
            {
                _fileMenu = new GenericMenu();
            }
            
            AddFileMenuItem(new GUIContent("New Graph"), false, _createGraph);
            
            AddFileMenuItem(new GUIContent("Open Graph"), false, _openGraph);            

            AddFileMenuItem(new GUIContent("Save as/Json"), false, _saveAsJson);
            AddFileMenuItem(new GUIContent("Read/Json"), false, _readJson);
            
            AddFileMenuItem(new GUIContent("Backup"), false, _backup);
            
            // AddMenuItem(new GUIContent("Save as/Binary"), false, _saveAsBinary);
            _backupStart();
        }

        private GenericMenu _fileMenu;
        private Rect _last;
        private event Action<Object> _onObjectSelectorClosed; 
        public override void OnGUI()
        {
            base.OnGUI();
            var eve = Event.current;

            if (eve.commandName == "ObjectSelectorClosed")
            {
                _onObjectSelectorClosed?.Invoke(EditorGUIUtility.GetObjectPickerObject());
            }

            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar,GUILayout.Width(window.position.width));
            {
                var menu = new GUIContent("File");
                var size = EditorStyles.toolbarButton.CalcSize(menu);
                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button(menu, EditorStyles.toolbarButton, GUILayout.Width(size.x)))
                    {
                        _last.position += new Vector2(0, 20);
                        _fileMenu.DropDown(_last);
                    }

                    _last = GUILayoutUtility.GetLastRect();   
                }
                EditorGUILayout.EndHorizontal();

                if (GUILayout.Button(new GUIContent((Texture) EditorGUIUtility.Load("aimconstraint icon"),"Positioning to Graph"),EditorStyles.toolbarButton, GUILayout.Height(size.y),GUILayout.Width(32)))
                {
                    Selection.activeObject = target;
                }
            }
            EditorGUILayout.EndHorizontal();
            
            _drawNodeTooltip();

            _backupHandle();
            
            window.Repaint();
        }

        private Texture2D _tooltipTexture;
        private GUIStyle  _tooltipStyle;
        private void _drawNodeTooltip()
        {
            var selects = Selection.objects;

            if (selects.Length == 0)
            {
                return;
            }
            
            var node = selects[0];

            var attr = node.GetType().GetCustomAttribute<NodeTooltipAttribute>();

            if (attr == null)
            {
                return;
            }

            var windowPos = this.window.position;

            var tooltipPos = windowPos;
            tooltipPos.position = windowPos.size - Setting.NodeTooltipSetting.Size;
            tooltipPos.size     = Setting.NodeTooltipSetting.Size;

            if (!_tooltipTexture)
            {
                _tooltipTexture = new Texture2D(1,1);
            }

            var color = Setting.NodeTooltipSetting.backgroundColor;
            
            _tooltipTexture.SetPixel(1, 1, color);
            
            _tooltipTexture.Apply();
            
            if (_tooltipStyle == null)
            {
                _tooltipStyle          = new GUIStyle(EditorStyles.label);
                _tooltipStyle.wordWrap = true;
            }

            _tooltipStyle.fontSize = Setting.NodeTooltipSetting.FontSize;
            
            GUI.DrawTexture(tooltipPos, _tooltipTexture);
            GUI.BeginClip(tooltipPos);
            {
                GUILayout.Space(-20);
                GUILayout.Label(attr.Tooltip, _tooltipStyle);
            }
            GUI.EndClip();
        }

        public void AddFileMenuItem(GUIContent content, bool on, Action clickCallback)
        {
            _fileMenu.AddItem(content, on, clickCallback.Invoke);
        }
        
        public void AddFileMenuItem(GUIContent content, bool on,object userData, Action<object> clickCallback)
        {
            _fileMenu.AddItem(content, on, clickCallback.Invoke,userData);
        }

        private void _saveAsBinary()
        {
            var path = EditorUtility.SaveFilePanel("Save Path", Application.dataPath, target.name, "bin");
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
                    tooltip = string.IsNullOrEmpty(tooltipAttribute.Tooltip) ? tooltip : tooltipAttribute.Tooltip +" "+ tooltip;
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
        public class NodeTooltipSetting
        {
            public Vector2 Size;

            public int FontSize;

            public Color backgroundColor;

            [NonSerialized] 
            private bool _exap;

            public NodeTooltipSetting()
            {
                var color = Color.gray;
                color.a         = 0.5f;
                backgroundColor = color;
                FontSize        = EditorStyles.label.fontSize;
            }

            internal void Draw()
            {
                EditorGUILayout.BeginVertical("box");
                {
                    _exap =
                        EditorGUILayout.Foldout(_exap, "Node Tooltip Setting", true);

                    if (Setting.NodeTooltipSetting._exap)
                    {
                        EditorGUI.BeginChangeCheck();
                        {
                            Size            = EditorGUILayout.Vector2Field("Size", Size);
                            FontSize        = EditorGUILayout.IntField("Font Size", FontSize);
                            backgroundColor = EditorGUILayout.ColorField("Background Color", backgroundColor);
                        }
                        if (EditorGUI.EndChangeCheck())
                        {
                            Setting.Save();
                        }
                    }
                }
                EditorGUILayout.EndVertical();
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

            public double SaveTime => Math.Max(saveTime,1);

            public string SaveFolder
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(saveFolder))
                    {
                        saveFolder = $"{Application.dataPath.Replace("Assets", "IcSkillBackups")}";
                    }

                    if (!Directory.Exists(saveFolder))
                    {
                        Directory.CreateDirectory(saveFolder);
                    }
                    
                    return saveFolder;
                }
            }

            public NodeTooltipSetting NodeTooltipSetting;

            [SerializeField]
            internal double saveTime;

            [SerializeField] 
            internal string saveFolder;

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
                        processorAqName = typeof(DefaultAssetProcessor).AssemblyQualifiedName
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

            EditorGUILayout.BeginVertical("box");
            {
                EditorGUI.BeginChangeCheck();
                {
                    Setting.saveTime = EditorGUILayout.DelayedDoubleField("Auto Save Time", Setting.SaveTime);
                }
                if (EditorGUI.EndChangeCheck())
                {
                    Setting.Save();
                }


                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Save Folder");
                    if (GUILayout.Button("Select"))
                    {
                        Setting.saveFolder = EditorUtility.OpenFolderPanel("Save Folder", Setting.SaveFolder, string.Empty);
                        Setting.Save();
                    }

                    if (GUILayout.Button(Setting.SaveFolder,"Label"))
                    {
                        InternalOpenFolder(Setting.SaveFolder);
                    }
                }
                EditorGUILayout.EndHorizontal();

                Setting.NodeTooltipSetting.Draw();
            }
            EditorGUILayout.EndVertical();
        }
        
        static void InternalOpenFolder(string folder)
        {
            folder = string.Format("\"{0}\"", folder);
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    Process.Start("Explorer.exe", folder.Replace('/', '\\'));
                    break;
                case RuntimePlatform.OSXEditor:
                    Process.Start("open", folder);
                    break;
                default:
                    throw new NotImplementedException(string.Format("Not support open folder on '{0}' platform.", Application.platform.ToString()));
            }
        }
    }
}