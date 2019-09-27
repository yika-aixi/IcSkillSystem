using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/OffMeshLinkData Value")]
    public partial class OffMeshLinkDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.OffMeshLinkData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.OffMeshLinkData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}