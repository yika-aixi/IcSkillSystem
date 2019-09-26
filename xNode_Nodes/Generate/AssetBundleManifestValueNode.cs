using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/AssetBundleManifest Value")]
    public partial class AssetBundleManifestValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AssetBundleManifest _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AssetBundleManifest);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}