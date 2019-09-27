using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectInt Value")]
    public partial class RectIntValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RectInt _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RectInt);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}