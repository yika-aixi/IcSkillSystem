using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ClothModule/ClothSphereColliderPair Value")]
    public partial class ClothSphereColliderPairValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ClothSphereColliderPair _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ClothSphereColliderPair);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}