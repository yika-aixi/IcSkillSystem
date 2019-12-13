using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/NPBehave/Component Get Component")]
    public class ComponentGetComponentValueNode:DynamicValueNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private Component _target;

        public override Type BaseType => typeof(Component);

        protected override object GetDynamicValue()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;
            }
#endif
            var target = GetInputValue(nameof(_target), _target);
            
            if (!target)
            {
                return null;
            }
            
            return target.GetComponent(GetCurrentValueType());
        }
    }
}