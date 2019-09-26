using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VFXModule/VisualEffectAsset Value")]
    public partial class VisualEffectAssetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.VFX.VisualEffectAsset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.VFX.VisualEffectAsset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}