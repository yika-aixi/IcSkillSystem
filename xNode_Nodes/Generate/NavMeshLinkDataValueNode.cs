using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/NavMeshLinkData Value")]
    public partial class NavMeshLinkDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AI.NavMeshLinkData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AI.NavMeshLinkData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}