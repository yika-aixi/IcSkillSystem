using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Mathf Value")]
    public partial class MathfValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Mathf _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Mathf);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}