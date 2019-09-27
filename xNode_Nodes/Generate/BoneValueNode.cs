using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/Bone Value")]
    public partial class BoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.Bone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.Bone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}