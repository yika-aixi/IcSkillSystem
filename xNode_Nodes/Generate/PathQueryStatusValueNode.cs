using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AIModule/PathQueryStatus Value")]
    public partial class PathQueryStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.AI.PathQueryStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.AI.PathQueryStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}