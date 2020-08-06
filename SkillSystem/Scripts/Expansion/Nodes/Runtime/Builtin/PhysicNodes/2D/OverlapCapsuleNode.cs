//Create: Icarus
//ヾ(•ω•`)o
//2020-07-06 01:47
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/2D/Overlap Capsule Cast")]
    public class OverlapCapsuleNode:ACast2DNode<Collider2D>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<Vector2> _size;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<CapsuleDirection2D> _direction;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private ValueInfo<float> _angle;
        
        protected override int OnCast()
        {
            return Physics2D.OverlapCapsuleNonAlloc(GetPoint(), GetInputValue(nameof(_size), _size),
                    GetInputValue(nameof(_direction), _direction),
                    GetInputValue(nameof(_angle), _angle), Result, Mask, MinDepth, MaxDepth);
        }

#if UNITY_EDITOR
        private GameObject _debugGO;
        private Mesh _mesh;
        protected override void OnDrawGizmos()
        {
            UnityEngine.Debug.Log("[2D Overlap Capsule Cast Node] Does not guarantee display accuracy");
            if (!_debugGO)
            {
                _debugGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                _debugGO.hideFlags = HideFlags.HideInHierarchy;
                _debugGO.transform.position = new Vector3(99999,99999);
                _mesh = _debugGO.GetComponent<MeshFilter>().mesh;
            }

            var size = GetInputValue(nameof(_size), _size).Value;
            var dir = GetInputValue(nameof(_direction), _direction).Value;
            var axis = Vector3.forward;
            var angle = GetInputValue(nameof(_angle), _angle).Value;
            if (dir == CapsuleDirection2D.Horizontal)
            {
                Quaternion.Euler(0,0,-90).ToAngleAxis(out var an,out _);
                angle += an;
            }
            
            Gizmos.DrawMesh(_mesh, GetPoint(), Quaternion.AngleAxis(angle, Vector3.forward),
                new Vector3(size.x,size.y,1));
        }
#endif
    }
}