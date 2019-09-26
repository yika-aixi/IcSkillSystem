using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AssetBundleModule/AssetBundle Value")]
    public partial class AssetBundleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AssetBundle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AssetBundle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}