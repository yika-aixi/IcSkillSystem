using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector4 Value")]
    public partial class Vector4ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Vector4 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Vector4);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}