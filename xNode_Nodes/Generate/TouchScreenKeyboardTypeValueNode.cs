using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TouchScreenKeyboardType Value")]
    public partial class TouchScreenKeyboardTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TouchScreenKeyboardType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TouchScreenKeyboardType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}