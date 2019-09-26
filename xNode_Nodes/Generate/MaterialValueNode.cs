using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Material Value")]
    public partial class MaterialValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Material _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Material);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}