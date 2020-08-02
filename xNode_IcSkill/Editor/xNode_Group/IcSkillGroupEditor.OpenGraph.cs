//Create: Icarus
//ヾ(•ω•`)o
//2020-08-03 12:16
//CabinIcarus.IcSkillSystem.xNodeIc.Editor

using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    public partial class IcSkillGroupEditor
    {
        private void _openGraph()
        {
            _onObjectSelectorClosed += _openGraph;
            EditorGUIUtility.ShowObjectPicker<IcSkillGraph>(null, false,string.Empty,0);
        }

        private void _openGraph(Object obj)
        {
            _onObjectSelectorClosed -= _openGraph;
            
            _openGraph((IcSkillGraph) obj);
        }

        private static void _openGraph(IcSkillGraph asset)
        {
            var              windows = Resources.FindObjectsOfTypeAll<NodeEditorWindow>();
            NodeEditorWindow w       = null;

            foreach (var window in windows)
            {
                if (window.Lock)
                {
                    continue;
                }

                var result = EditorUtility.DisplayDialog("Warning",
                    "Editing currently exists, whether to open a window or overwrite it", "old Window", "new Window");

                if (!result)
                {
                    window.Lock = true;
                }

                break;
            }

            NodeEditorWindow.Open(asset);
        }
    }
}