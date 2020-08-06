//Create: Icarus
//ヾ(•ω•`)o
//2020-07-06 01:48
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/2D/Overlap Point Cast")]
    public class OverlapPointNode:ACast2DNode<Collider2D>
    {
        [PortTooltip("no input use Owner Point")]
        [Input(ShowBackingValue.Always, ConnectionType.Override, TypeConstraint.Strict)]
        private ValueInfo<Vector2> _point;
        
        protected override int OnCast()
        {
            return Physics2D.OverlapPointNonAlloc(GetPoint(),
                    Result, Mask, MinDepth, MaxDepth);
        }

        protected override void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(GetPoint(), 0.1f);
        }
    }
}