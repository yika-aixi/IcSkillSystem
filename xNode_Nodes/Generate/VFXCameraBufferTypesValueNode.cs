using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VFXModule/VFXCameraBufferTypes Value")]
    public partial class VFXCameraBufferTypesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.VFX.VFXCameraBufferTypes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.VFX.VFXCameraBufferTypes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}