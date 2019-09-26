using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteMaskModule/SpriteMask Value")]
    public partial class SpriteMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}