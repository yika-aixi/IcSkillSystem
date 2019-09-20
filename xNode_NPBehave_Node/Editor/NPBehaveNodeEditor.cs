using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEditor;
using UnityEngine;
using XNodeEditor;
using EditorGUIUtility = UnityEditor.Experimental.Networking.PlayerConnection.EditorGUIUtility;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(NPBehaveNode))]
    public class NPBehaveNodeEditor:NodeEditor 
    {
        private NPBehaveNode _node;
        private Color _backColor;
        public void _check()
        {
            if (_node == null) _node = target as NPBehaveNode;
            _backColor = GUI.color;
        }

        public override Color GetTint()
        {
            _check();

            var NPBNodeInputs = _node.Inputs.Where(x => typeof(NPBehaveNode).IsAssignableFrom(x.ValueType));
            
            foreach (var nodePort in NPBNodeInputs)
            {
                if (nodePort.ConnectionCount == 0)
                {
                    return Color.red;
                }
            }
            
            return base.GetTint();
        }

        public override void OnBodyGUI()
        {
            _check();

            if (_node.Inputs != null && _node.Node == null)
            {
                GUI.tooltip = "缺失连接点";
            }
            
            base.OnBodyGUI();
        }
    }
}