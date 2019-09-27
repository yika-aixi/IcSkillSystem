using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/TouchPhase Value")]
    public partial class TouchPhaseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TouchPhase _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TouchPhase);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}