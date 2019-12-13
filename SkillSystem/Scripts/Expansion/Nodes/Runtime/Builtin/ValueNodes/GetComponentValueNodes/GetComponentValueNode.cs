using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/NPBehave/Go Get Component")]
    public class GetComponentValueNode:DynamicValueNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("No Input use Owner")]
        private GameObject _target;
        
        public override Type BaseType { get; } = typeof(Component);

        protected override object GetDynamicValue()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
            var target = GetInputValue(nameof(_target), SkillGroup.Owner);

            return target.GetComponent(GetCurrentValueType());
        }
    }
}