using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ClusterInputModule/ClusterInputType Value")]
    public partial class ClusterInputTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ClusterInputType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ClusterInputType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}