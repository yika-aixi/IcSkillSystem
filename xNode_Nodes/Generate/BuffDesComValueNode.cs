using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/BuffDesCom Value")]
    public partial class BuffDesComValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.BuffDesCom _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.BuffDesCom);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}