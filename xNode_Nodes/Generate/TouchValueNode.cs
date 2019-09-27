using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/Touch Value")]
    public partial class TouchValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Touch _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Touch);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}