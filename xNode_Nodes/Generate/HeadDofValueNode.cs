using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HeadDof Value")]
    public partial class HeadDofValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HeadDof _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HeadDof);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}