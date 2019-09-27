using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/BodyDof Value")]
    public partial class BodyDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BodyDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BodyDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}