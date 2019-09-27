using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CachedAssetBundle Value")]
    public partial class CachedAssetBundleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CachedAssetBundle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CachedAssetBundle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}