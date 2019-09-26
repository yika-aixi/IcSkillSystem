using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/FrictionJoint2D Value")]
    public partial class FrictionJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FrictionJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FrictionJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}