//Create: Icarus
//ヾ(•ω•`)o
//2020-07-06 01:48
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/2D/Overlap Circle Cast")]
    public class OverlapCircleNode:ACast2DNode<Collider2D>
    {
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        private ValueInfo<float> _radius;

      protected override int OnCast()
      {
          return Physics2D.OverlapCircleNonAlloc(GetPoint(),
              GetInputValue(nameof(_radius), _radius), Result, Mask, MinDepth, MaxDepth);
      }

      protected override void OnDrawGizmos()
      {
          Gizmos.DrawWireSphere(GetPoint(),GetInputValue(nameof(_radius), _radius));
      }
    }
}