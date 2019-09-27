using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/WaitNode_Seconds Value")]
    public partial class WaitNode_SecondsValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_Seconds _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_Seconds);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}