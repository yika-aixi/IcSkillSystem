using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CursorLockMode Value")]
    public partial class CursorLockModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CursorLockMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CursorLockMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}