using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ClothModule/Cloth Value")]
    public partial class ClothValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Cloth _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Cloth);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}