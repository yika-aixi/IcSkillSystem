using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/CompressionLevel Value")]
    public partial class CompressionLevelValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CompressionLevel _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CompressionLevel);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}