using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/PolygonId Value")]
    public partial class PolygonIdValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.PolygonId _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.PolygonId);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}