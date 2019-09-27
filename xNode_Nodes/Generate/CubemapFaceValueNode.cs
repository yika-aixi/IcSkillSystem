using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CubemapFace Value")]
    public partial class CubemapFaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CubemapFace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CubemapFace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}