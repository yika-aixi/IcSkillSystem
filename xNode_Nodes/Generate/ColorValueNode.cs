using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color Value")]
    public partial class ColorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Color _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Color);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}