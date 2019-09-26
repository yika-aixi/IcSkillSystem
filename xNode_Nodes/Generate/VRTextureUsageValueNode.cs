using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/VRTextureUsage Value")]
    public partial class VRTextureUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.VRTextureUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.VRTextureUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}