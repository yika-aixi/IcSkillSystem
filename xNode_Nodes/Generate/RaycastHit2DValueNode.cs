using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RaycastHit2D Value")]
    public partial class RaycastHit2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RaycastHit2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RaycastHit2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}