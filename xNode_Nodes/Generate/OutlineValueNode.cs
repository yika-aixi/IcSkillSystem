using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Outline Value")]
    public partial class OutlineValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Outline _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Outline);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}