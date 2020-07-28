using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Target Position")]
    public class GetTargetPosition:ValueNode<Vector3>
    { 
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use Owner")]
        private GameObject _target;

        [SerializeField, Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private bool _loacal;
        protected override Vector3 GetTValue()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Vector3.zero;
            }
#endif
            var target = GetInputValue(nameof(_target), SkillGraph.Owner);

            if (_loacal)
            {
                return target.transform.localPosition;
            }

            return target.transform.position;
        }
    }
}