using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/UnityEvent Value")]
    public partial class UnityEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Events.UnityEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Events.UnityEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}