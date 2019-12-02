using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACastRaycastHit3DNode:ACastRaycastHitNode
    {
        [SerializeField,Input(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        private Vector3 _direction;
        
        [SerializeField,Input(Node.ShowBackingValue.Always,Node.ConnectionType.Override,Node.TypeConstraint.Strict)]
        private float _maxDistance;

        protected Vector3 Direction => GetInputValue(nameof(_direction), _direction);

        public float MaxDistance => GetInputValue(nameof(_maxDistance),_maxDistance);
        
        protected RaycastHit[] Buffer;

        [SerializeField]
        protected QueryTriggerInteraction TriggerInteraction;
        
        [Output()]    
        [PortTooltip("result is `IEnumerable<RaycastHit>`")]
        protected IEnumerable<RaycastHit> Result;
        
        protected ACastRaycastHit3DNode()
        {
            if (MaxHitSize < 1)
            {
                MaxHitSize = 1;
            }
            
            Buffer = new RaycastHit[MaxHitSize];
        }

        protected override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(Result))
            {
                return Result;
            }
            
            return null;
        }
    }
}