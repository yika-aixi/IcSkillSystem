using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACast3DNode:ACastNode
    {
        protected RaycastHit[] Buffer;
        
        [Output(ShowBackingValue.Never,ConnectionType.Multiple,TypeConstraint.Inherited)]    
        protected IEnumerable<RaycastHit> Result;
        
        protected ACast3DNode()
        {
            if (MaxHitSize < 1)
            {
                MaxHitSize = 1;
            }
            
            Result = new RaycastHit[MaxHitSize];
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