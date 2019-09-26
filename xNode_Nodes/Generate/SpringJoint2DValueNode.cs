using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SpringJoint2D Value")]
    public partial class SpringJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpringJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpringJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}