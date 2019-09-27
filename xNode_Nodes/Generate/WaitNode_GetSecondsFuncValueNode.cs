using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/WaitNode_GetSecondsFunc Value")]
    public partial class WaitNode_GetSecondsFuncValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_GetSecondsFunc _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_GetSecondsFunc);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}