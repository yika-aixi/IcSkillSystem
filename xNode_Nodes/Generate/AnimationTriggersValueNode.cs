using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/AnimationTriggers Value")]
    public partial class AnimationTriggersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.AnimationTriggers _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.AnimationTriggers);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}