using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/OcclusionPortal Value")]
    public partial class OcclusionPortalValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.OcclusionPortal _value;

        public override Type ValueType { get; } = typeof(UnityEngine.OcclusionPortal);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}