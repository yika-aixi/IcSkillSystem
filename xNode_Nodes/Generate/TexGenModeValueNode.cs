using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TexGenMode Value")]
    public partial class TexGenModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TexGenMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TexGenMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}