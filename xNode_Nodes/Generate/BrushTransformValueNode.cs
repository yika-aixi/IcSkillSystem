using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/BrushTransform Value")]
    public partial class BrushTransformValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.TerrainAPI.BrushTransform _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.TerrainAPI.BrushTransform);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}