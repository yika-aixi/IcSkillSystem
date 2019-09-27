using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Matrix4x4 Value")]
    public partial class Matrix4x4ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Matrix4x4 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Matrix4x4);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}