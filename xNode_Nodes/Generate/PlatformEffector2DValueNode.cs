using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PlatformEffector2D Value")]
    public partial class PlatformEffector2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PlatformEffector2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PlatformEffector2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}