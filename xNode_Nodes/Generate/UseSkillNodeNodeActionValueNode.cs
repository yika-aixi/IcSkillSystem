using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/UseSkillNodeNodeAction Value")]
    public partial class UseSkillNodeNodeActionValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.UseSkillNodeNodeAction _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.UseSkillNodeNodeAction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}