using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PropertyName Value")]
    public partial class PropertyNameValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PropertyName _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PropertyName);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}