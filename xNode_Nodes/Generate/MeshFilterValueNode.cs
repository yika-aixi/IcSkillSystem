using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MeshFilter Value")]
    public partial class MeshFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MeshFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MeshFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}