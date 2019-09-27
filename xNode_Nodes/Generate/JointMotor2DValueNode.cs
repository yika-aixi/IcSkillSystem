using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointMotor2D Value")]
    public partial class JointMotor2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointMotor2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointMotor2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}