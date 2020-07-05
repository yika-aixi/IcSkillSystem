using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/3D/Overlap Sphere Cast")]
    public class OverlapSphereNode:ACast3DNode<Collider>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IcVariableSingle _radius;

        protected override int OnCast()
        {
            return Physics.OverlapSphereNonAlloc(Origin, GetInputValue(nameof(_radius),_radius), Result, Mask,TriggerInteraction);
        }

        protected override void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(Origin,GetInputValue(nameof(_radius),_radius));
        }
    }
}