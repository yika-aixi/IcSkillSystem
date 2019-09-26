using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SurfaceEffector2D Value")]
    public partial class SurfaceEffector2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SurfaceEffector2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SurfaceEffector2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}