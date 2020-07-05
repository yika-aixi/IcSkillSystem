using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACast3DColliderNode:ACastNode
    {
        protected Collider[] Buffer;

        [SerializeField]
        protected QueryTriggerInteraction TriggerInteraction;
        
        [Node.OutputAttribute()]    
        [PortTooltip("result is `IEnumerable<Collider>`")]
        protected IEnumerable<Collider> Result;
        
        protected ACast3DColliderNode()
        {
            if (MaxHitSize < 1)
            {
                MaxHitSize = 1;
            }
            
            Buffer = new Collider[MaxHitSize];
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