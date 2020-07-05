//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 11:18
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Condition/Physic/2D/Overlap Box Cast")]
    public class OverlapBoxNode:ACast2DNode<Collider2D>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IcVariableVector2 _size;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IcVariableSingle _angle;
        
        protected override int OnCast()
        {
            return Physics2D.OverlapBoxNonAlloc(GetPoint(), GetInputValue(nameof(_size),_size), GetInputValue(nameof(_angle),_angle), Result,Mask,MinDepth,MaxDepth);
        }

        
#if UNITY_EDITOR
        private GameObject _debugGO;
        private Mesh _mesh;
        protected override void OnDrawGizmos()
        {
            UnityEngine.Debug.Log("[2D Overlap Box Cast Node] Does not guarantee display accuracy");
            if (!_debugGO)
            {
                _debugGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _debugGO.hideFlags = HideFlags.HideInHierarchy;
                _debugGO.transform.position = new Vector3(99999,99999);
                _mesh = _debugGO.GetComponent<MeshFilter>().mesh;
            }
            var size = GetInputValue(nameof(_size),_size).Value;
            
            Gizmos.DrawMesh(_mesh,GetPoint(), Quaternion.AngleAxis(GetInputValue(nameof(_angle),_angle),Vector3.forward), new Vector3(size.x,size.y,1));
        }
#endif
    }
}