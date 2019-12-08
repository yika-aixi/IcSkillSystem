using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/NPBehave/Component Get Component")]
    public abstract class ComponentGetComponentValueNode:ValueNode
    {
        public override Type ValueType { get; } = typeof(Component);

        public override bool IsChangeValueType { get; } = true;

        public override Type BaseType { get; } = typeof(Component);

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private Component _target;
        
        protected override object GetOutValue()
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