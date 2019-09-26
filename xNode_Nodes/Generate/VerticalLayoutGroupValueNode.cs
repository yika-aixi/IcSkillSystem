using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/VerticalLayoutGroup Value")]
    public partial class VerticalLayoutGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.VerticalLayoutGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.VerticalLayoutGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}