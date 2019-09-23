using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Repeater")]
    public class RepeaterNode:ADecoratorNode
    {
        [SerializeField]
        private int _loopCount;
        
        protected override void CreateNode()
        {
            base.CreateNode();
            
            Node = new Repeater(_loopCount, DecorateeNode.Node);
        }
    }
}