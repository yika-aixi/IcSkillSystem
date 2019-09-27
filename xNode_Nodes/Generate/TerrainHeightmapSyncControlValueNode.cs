using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TerrainHeightmapSyncControl Value")]
    public partial class TerrainHeightmapSyncControlValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainHeightmapSyncControl _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainHeightmapSyncControl);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}