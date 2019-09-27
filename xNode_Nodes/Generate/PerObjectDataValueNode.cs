using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PerObjectData Value")]
    public partial class PerObjectDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.PerObjectData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.PerObjectData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}