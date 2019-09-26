using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/ContentSizeFitter Value")]
    public partial class ContentSizeFitterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.ContentSizeFitter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.ContentSizeFitter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}