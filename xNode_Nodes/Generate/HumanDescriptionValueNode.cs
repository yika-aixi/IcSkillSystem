using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanDescription Value")]
    public partial class HumanDescriptionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanDescription _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanDescription);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}