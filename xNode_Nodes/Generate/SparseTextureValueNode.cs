using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SparseTexture Value")]
    public partial class SparseTextureValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SparseTexture _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SparseTexture);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}