using System.Linq;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Condition/Physic/Sphere Cast")]
    public class OverlapSphereNode:ACast3DColliderNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private float _radius;

        protected override bool CastCheck()
        {
            DebugStart();
            bool result;
            if (UseAll)
            {
                var size = Physics.OverlapSphereNonAlloc(Origin, GetInputValue(nameof(_radius),_radius), Buffer, Mask,TriggerInteraction);

                if (size == 0)
                {
                    result = false;
                }
                else
                {
                    Result = Buffer.Take(size);
                
                    DebugStop();
                
                    result = true;
                }
            }

            DebugStop();
            
            return result;
        }

        protected override void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(Origin,GetInputValue(nameof(_radius),_radius));
        }
    }
}