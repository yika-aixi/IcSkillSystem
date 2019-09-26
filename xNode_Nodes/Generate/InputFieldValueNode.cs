using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/InputField Value")]
    public partial class InputFieldValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.InputField _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.InputField);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}