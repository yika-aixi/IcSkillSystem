using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsFenceType Value")]
    public partial class GraphicsFenceTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GraphicsFenceType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GraphicsFenceType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}