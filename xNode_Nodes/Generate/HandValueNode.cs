using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/Hand Value")]
    public partial class HandValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.Hand _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.Hand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}