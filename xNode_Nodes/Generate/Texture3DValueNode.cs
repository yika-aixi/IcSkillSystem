using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Texture3D Value")]
    public partial class Texture3DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Texture3D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Texture3D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}