using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Hash128 Value")]
    public partial class Hash128ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Hash128 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Hash128);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}