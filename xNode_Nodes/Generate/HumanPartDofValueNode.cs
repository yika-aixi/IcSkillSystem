using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanPartDof Value")]
    public partial class HumanPartDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanPartDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanPartDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}