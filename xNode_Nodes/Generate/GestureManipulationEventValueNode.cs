using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureManipulationEvent Value")]
    public partial class GestureManipulationEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureManipulationEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureManipulationEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}