using CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(AAutoExecuteNode))]
    public class AutoExecuteNodeEditor: NodeEditor
    {
        private AAutoExecuteNode _autoExecuteNode;
        private SerializedProperty _autoStartSer;
        private SerializedProperty _prioritySer;

        public override Color GetTint()
        {
            _check();
            
            return new Color(30 / 255f,147 / 255f,65 / 255f);
        }

        public override void OnCreate()
        {
            base.OnCreate();
            
            _check();
        }
      
        private void _check()
        {
            if (_autoExecuteNode == null) _autoExecuteNode = target as AAutoExecuteNode;
        }
    }
}