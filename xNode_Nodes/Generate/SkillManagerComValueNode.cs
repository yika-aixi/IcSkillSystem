using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/SkillManagerCom Value")]
    public partial class SkillManagerComValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.SkillManagerCom _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.SkillManagerCom);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}