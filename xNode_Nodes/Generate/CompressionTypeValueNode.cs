using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/CompressionType Value")]
    public partial class CompressionTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CompressionType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CompressionType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}