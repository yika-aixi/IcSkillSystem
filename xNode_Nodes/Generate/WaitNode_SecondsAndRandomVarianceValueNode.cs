using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/WaitNode_SecondsAndRandomVariance Value")]
    public partial class WaitNode_SecondsAndRandomVarianceValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_SecondsAndRandomVariance _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.WaitNode_SecondsAndRandomVariance);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}