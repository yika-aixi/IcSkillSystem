using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/QueueMode Value")]
    public partial class QueueModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.QueueMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.QueueMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}