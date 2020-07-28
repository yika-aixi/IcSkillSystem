using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Target Forward")]
    public class GetTargetForward:ValueNode<Vector3>
    { 
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use Owner")]
        private GameObject _target;

        [SerializeField]
        private bool _isReverse;

        protected override Vector3 GetTValue()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Vector3.zero;
            }
#endif
            var target = GetInputValue(nameof(_target), SkillGraph.Owner);

            var forward = target.transform.forward;

            return _isReverse ? -forward : forward;
        }
    }
}