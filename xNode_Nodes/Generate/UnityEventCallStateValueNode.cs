using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/UnityEventCallState Value")]
    public partial class UnityEventCallStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Events.UnityEventCallState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Events.UnityEventCallState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}