using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/WaitNode_BlackboardGetSeconds Value")]
    public partial class WaitNode_BlackboardGetSecondsValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_BlackboardGetSeconds _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_BlackboardGetSeconds);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}