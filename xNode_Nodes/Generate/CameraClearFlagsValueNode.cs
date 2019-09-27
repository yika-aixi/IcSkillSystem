using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraClearFlags Value")]
    public partial class CameraClearFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CameraClearFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CameraClearFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}