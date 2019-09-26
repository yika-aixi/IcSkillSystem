using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LogType Value")]
    public partial class LogTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LogType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LogType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}