using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Space Value")]
    public partial class SpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Space _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Space);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}