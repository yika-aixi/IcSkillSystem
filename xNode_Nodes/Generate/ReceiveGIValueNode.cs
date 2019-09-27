using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReceiveGI Value")]
    public partial class ReceiveGIValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ReceiveGI _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ReceiveGI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}