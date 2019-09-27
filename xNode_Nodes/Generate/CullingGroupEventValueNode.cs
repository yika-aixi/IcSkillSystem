using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CullingGroupEvent Value")]
    public partial class CullingGroupEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CullingGroupEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CullingGroupEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}