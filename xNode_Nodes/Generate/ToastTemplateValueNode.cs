using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ToastTemplate Value")]
    public partial class ToastTemplateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.ToastTemplate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.ToastTemplate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}