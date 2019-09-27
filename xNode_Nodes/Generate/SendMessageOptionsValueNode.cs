using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SendMessageOptions Value")]
    public partial class SendMessageOptionsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SendMessageOptions _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SendMessageOptions);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}