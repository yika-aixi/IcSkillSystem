using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/FocusType Value")]
    public partial class FocusTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FocusType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FocusType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}