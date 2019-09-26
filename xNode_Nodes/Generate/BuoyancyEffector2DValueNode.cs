using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/BuoyancyEffector2D Value")]
    public partial class BuoyancyEffector2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BuoyancyEffector2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BuoyancyEffector2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}