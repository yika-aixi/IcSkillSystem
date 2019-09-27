using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2 Value")]
    public partial class Vector2ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Vector2 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Vector2);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}