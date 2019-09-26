using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/HorizontalLayoutGroup Value")]
    public partial class HorizontalLayoutGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.HorizontalLayoutGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.HorizontalLayoutGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}