using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(ActionNode))]
    public class ActionNodeEditor:NodeEditor
    {
        public override Color GetTint()
        {
            if (!target.GetInputPort("_executeNode").IsConnected)
            {
                return Color.red;
            }
            
            return base.GetTint();
        }
    }
}