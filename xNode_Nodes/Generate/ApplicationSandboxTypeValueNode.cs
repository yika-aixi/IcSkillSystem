using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ApplicationSandboxType Value")]
    public partial class ApplicationSandboxTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ApplicationSandboxType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ApplicationSandboxType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}