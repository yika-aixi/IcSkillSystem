using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTargetSetup Value")]
    public partial class RenderTargetSetupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTargetSetup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTargetSetup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}