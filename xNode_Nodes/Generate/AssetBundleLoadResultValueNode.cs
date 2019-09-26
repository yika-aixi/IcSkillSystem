using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/AssetBundleLoadResult Value")]
    public partial class AssetBundleLoadResultValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AssetBundleLoadResult _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AssetBundleLoadResult);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}