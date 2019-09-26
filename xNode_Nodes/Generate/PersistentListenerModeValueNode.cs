using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PersistentListenerMode Value")]
    public partial class PersistentListenerModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Events.PersistentListenerMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Events.PersistentListenerMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}