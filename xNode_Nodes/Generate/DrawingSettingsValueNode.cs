using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DrawingSettings Value")]
    public partial class DrawingSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.DrawingSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.DrawingSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}