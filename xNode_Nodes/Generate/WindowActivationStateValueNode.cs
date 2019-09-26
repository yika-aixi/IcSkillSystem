using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/WindowActivationState Value")]
    public partial class WindowActivationStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.WindowActivationState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.WindowActivationState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}