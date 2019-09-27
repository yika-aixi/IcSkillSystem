using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/IcSkillGroup Value")]
    public partial class IcSkillGroupValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.xNode_Group.IcSkillGroup _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.xNode_Group.IcSkillGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}