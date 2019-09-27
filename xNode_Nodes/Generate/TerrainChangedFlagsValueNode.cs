using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TerrainChangedFlags Value")]
    public partial class TerrainChangedFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainChangedFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainChangedFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}