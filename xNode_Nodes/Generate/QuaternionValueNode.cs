using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Quaternion Value")]
    public partial class QuaternionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Quaternion _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Quaternion);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}