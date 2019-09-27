using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureManipulationValidFields Value")]
    public partial class GestureManipulationValidFieldsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureManipulationValidFields _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureManipulationValidFields);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}