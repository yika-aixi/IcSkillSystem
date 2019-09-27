using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DefaultFormat Value")]
    public partial class DefaultFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.DefaultFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.DefaultFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}