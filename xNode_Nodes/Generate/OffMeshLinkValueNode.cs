using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/OffMeshLink Value")]
    public partial class OffMeshLinkValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.OffMeshLink _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.OffMeshLink);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}