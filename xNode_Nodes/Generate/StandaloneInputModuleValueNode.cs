using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/StandaloneInputModule Value")]
    public partial class StandaloneInputModuleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.StandaloneInputModule _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.StandaloneInputModule);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}