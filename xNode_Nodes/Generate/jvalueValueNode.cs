using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AndroidJNIModule/jvalue Value")]
    public partial class jvalueValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.jvalue _value;

        public override Type ValueType { get; } = typeof(UnityEngine.jvalue);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}