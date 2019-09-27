using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color32 Value")]
    public partial class Color32ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Color32 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Color32);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}