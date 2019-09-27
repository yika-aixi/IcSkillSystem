using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsFence Value")]
    public partial class GraphicsFenceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GraphicsFence _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GraphicsFence);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}