using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/Eyes Value")]
    public partial class EyesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.Eyes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.Eyes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}