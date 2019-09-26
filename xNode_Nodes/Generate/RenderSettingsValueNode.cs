using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderSettings Value")]
    public partial class RenderSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}