using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureNavigationValidFields Value")]
    public partial class GestureNavigationValidFieldsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureNavigationValidFields _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureNavigationValidFields);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}