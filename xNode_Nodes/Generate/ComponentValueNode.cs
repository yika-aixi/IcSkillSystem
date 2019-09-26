using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Component Value")]
    public partial class ComponentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Component _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Component);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}