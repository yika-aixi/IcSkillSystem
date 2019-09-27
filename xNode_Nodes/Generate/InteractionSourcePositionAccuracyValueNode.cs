using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourcePositionAccuracy Value")]
    public partial class InteractionSourcePositionAccuracyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourcePositionAccuracy _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourcePositionAccuracy);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}