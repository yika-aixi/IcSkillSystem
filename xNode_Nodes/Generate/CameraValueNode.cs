using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Camera Value")]
    public partial class CameraValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Camera _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Camera);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}