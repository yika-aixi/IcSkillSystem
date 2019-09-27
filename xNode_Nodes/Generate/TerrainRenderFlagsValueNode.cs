using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TerrainRenderFlags Value")]
    public partial class TerrainRenderFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainRenderFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainRenderFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}