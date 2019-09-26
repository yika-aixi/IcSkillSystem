using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Button Value")]
    public partial class ButtonValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Button _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Button);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}