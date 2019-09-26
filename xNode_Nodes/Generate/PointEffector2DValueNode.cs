using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PointEffector2D Value")]
    public partial class PointEffector2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PointEffector2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PointEffector2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}