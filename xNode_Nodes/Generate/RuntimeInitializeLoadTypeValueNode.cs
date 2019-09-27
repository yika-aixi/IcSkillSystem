using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RuntimeInitializeLoadType Value")]
    public partial class RuntimeInitializeLoadTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RuntimeInitializeLoadType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RuntimeInitializeLoadType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}