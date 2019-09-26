using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/FontData Value")]
    public partial class FontDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.FontData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.FontData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}