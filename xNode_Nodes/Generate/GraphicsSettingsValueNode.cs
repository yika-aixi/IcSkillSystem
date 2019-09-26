using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsSettings Value")]
    public partial class GraphicsSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GraphicsSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GraphicsSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}