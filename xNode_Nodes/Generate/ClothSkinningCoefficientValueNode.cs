using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ClothModule/ClothSkinningCoefficient Value")]
    public partial class ClothSkinningCoefficientValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ClothSkinningCoefficient _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ClothSkinningCoefficient);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}