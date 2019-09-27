using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraType Value")]
    public partial class CameraTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CameraType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CameraType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}