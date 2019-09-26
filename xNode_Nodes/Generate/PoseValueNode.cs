using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Pose Value")]
    public partial class PoseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Pose _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Pose);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}