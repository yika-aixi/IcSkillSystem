using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Target Euler Value")]
    public class GetTargetEuler:ValueNode<Vector3>
    { 
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("no input use Owner")]
        private GameObject _target;

        protected override Vector3 GetTValue()
        {

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return Vector3.zero;
            }
#endif
            var target = GetInputValue(nameof(_target), SkillGraph.Owner);

            return target.transform.rotation.eulerAngles;
        }
    }
}