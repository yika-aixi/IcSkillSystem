using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Mesh Value")]
    public partial class MeshValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Mesh _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Mesh);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}