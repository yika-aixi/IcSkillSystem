using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshLinkInstance Value")]
    public partial class NavMeshLinkInstanceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshLinkInstance _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshLinkInstance);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}