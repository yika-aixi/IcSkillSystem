using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/KeyCode Value")]
    public partial class KeyCodeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.KeyCode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.KeyCode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}