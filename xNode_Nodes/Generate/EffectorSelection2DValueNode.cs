using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorSelection2D Value")]
    public partial class EffectorSelection2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EffectorSelection2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EffectorSelection2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}