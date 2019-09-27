using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourcePose Value")]
    public partial class InteractionSourcePoseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourcePose _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourcePose);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}