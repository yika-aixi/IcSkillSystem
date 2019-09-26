using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/LocalizationModule/LocalizationAsset Value")]
    public partial class LocalizationAssetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LocalizationAsset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LocalizationAsset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}