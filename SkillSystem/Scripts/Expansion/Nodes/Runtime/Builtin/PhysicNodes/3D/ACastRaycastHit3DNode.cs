using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACastRaycastHit3DNode:ACast3DNode<RaycastHit>
    {
        [SerializeField,Input(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        private IcVariableVector3 _direction;
        
        [SerializeField,Input(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        private IcVariableSingle _maxDistance;

        protected Vector3 Direction => GetInputValue(nameof(_direction), _direction);

        public float MaxDistance => GetInputValue(nameof(_maxDistance),_maxDistance);
    }
}