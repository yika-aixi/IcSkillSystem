using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BillboardAsset Value")]
    public partial class BillboardAssetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BillboardAsset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BillboardAsset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}