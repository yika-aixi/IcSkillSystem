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

        public override Type ValueType { get; } = typeof(Vector3);
        
        protected override object GetOutValue()
        {
            var target = GetInputValue(nameof(_target), SkillGroup.Owner);

            return target.transform.forward;
        }
    }
}