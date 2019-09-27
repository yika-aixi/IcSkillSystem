using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/SkillGroupTest Value")]
    public partial class SkillGroupTestValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.SkillGroupTest _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.SkillGroupTest);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}