using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RigidbodySleepMode2D Value")]
    public partial class RigidbodySleepMode2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RigidbodySleepMode2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RigidbodySleepMode2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}