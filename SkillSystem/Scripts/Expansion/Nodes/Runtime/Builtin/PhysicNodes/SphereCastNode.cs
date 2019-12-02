using System.Linq;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Condition/Physic/Sphere Cast")]
    public class SphereCastNode:ACast3DNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private float _radius;

        protected override bool CastCheck()
        {
            DebugStart();
            
            if (UseAll)
            {
                var size = Physics.SphereCastNonAlloc(Origin, GetInputValue(nameof(_radius),_radius), Direction, Buffer, MaxDistance, Mask);

                if (size == 0)
                {
                    return false;
                }
                
                Result = Buffer.Take(size);

                return true;
            }

            var result = Physics.SphereCast(Origin,GetInputValue(nameof(_radius),_radius),Direction,out var hit,MaxDistance,Mask);

            if (result)
            {
                Result = new[] {hit};
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