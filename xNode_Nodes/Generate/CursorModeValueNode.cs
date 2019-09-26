using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CursorMode Value")]
    public partial class CursorModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CursorMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CursorMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}