using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Target Forward")]
    public class GetTargetForward:ValueNode
    { 
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use Owner")]
        private GameObject _target;

        [SerializeField]
        private bool _isReverse;
        
        public override Type ValueType { get; } = typeof(Vector3);
        
        protected override object GetOutValue()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
            var target = GetInputValue(nameof(_target), SkillGroup.Owner);

            var forward = target.transform.forward;
            return _isReverse ? -forward : forward;
        }
    }
}