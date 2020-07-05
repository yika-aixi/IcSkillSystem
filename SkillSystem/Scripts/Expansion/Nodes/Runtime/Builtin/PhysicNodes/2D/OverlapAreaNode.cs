//Create: Icarus
//ヾ(•ω•`)o
//2020-07-06 01:43
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/2D/Overlap Area Cast")]
    public class OverlapAreaNode:ACast2DNode<Collider2D>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IcVariableVector2 _pointB;
        
        protected override int OnCast()
        {
            return Physics2D.OverlapAreaNonAlloc(GetPoint(), GetInputValue(nameof(_pointB), _pointB), Result, Mask,
                MinDepth, MaxDepth);
        }

        protected override void OnDrawGizmos()
        {
            UnityEngine.Debug.Log("[2D Overlap Area Cast Node] Does not guarantee display accuracy");
            Gizmos.DrawGUITexture(new Rect(GetPoint(), GetInputValue(nameof(_pointB), _pointB)),  Texture2D.whiteTexture);
        }
    }
}