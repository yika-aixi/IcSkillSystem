using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/StereoTargetEyeMask Value")]
    public partial class StereoTargetEyeMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.StereoTargetEyeMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.StereoTargetEyeMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}