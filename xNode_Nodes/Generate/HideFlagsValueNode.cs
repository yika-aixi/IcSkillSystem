using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/HideFlags Value")]
    public partial class HideFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HideFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HideFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}