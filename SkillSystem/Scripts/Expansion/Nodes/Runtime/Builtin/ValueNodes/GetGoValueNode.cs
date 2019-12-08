using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Component To GameObject")]
    public class GetGoValueNode:ValueNode
    {
        public override Type ValueType { get; } = typeof(GameObject);

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private Component _component;
        
        protected override object GetOutValue()
        {
            var com = GetInputValue(nameof(_component), _component);

            if (!com)
            {
                return null;
            }
            
            return com.gameObject;
        }
    }
}