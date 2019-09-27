using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LogOption Value")]
    public partial class LogOptionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LogOption _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LogOption);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}