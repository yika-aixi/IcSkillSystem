using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Text Value")]
    public partial class TextValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Text _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Text);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}