using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Target Position")]
    public class GetTargetPosition:ValueNode
    { 
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use Owner")]
        private GameObject _target;

        [SerializeField, Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private bool _loacal;
        
        public override Type ValueType { get; } = typeof(Vector3);
        
        protected override object GetOutValue()
        {
            var target = GetInputValue(nameof(_target), SkillGroup.Owner);

            if (_loacal)
            {
                return target.transform.localPosition;
            }

            return target.transform.position;
        }
    }
}