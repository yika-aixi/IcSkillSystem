using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/OffMeshLinkType Value")]
    public partial class OffMeshLinkTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.OffMeshLinkType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.OffMeshLinkType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}