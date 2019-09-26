using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Joint2D Value")]
    public partial class Joint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Joint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Joint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}