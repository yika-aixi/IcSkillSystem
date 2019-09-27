using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowDrawingSettings Value")]
    public partial class ShadowDrawingSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShadowDrawingSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShadowDrawingSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}