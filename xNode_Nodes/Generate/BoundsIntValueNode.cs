using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BoundsInt Value")]
    public partial class BoundsIntValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoundsInt _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoundsInt);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}