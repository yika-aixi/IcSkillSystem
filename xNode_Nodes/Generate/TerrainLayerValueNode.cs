using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TerrainLayer Value")]
    public partial class TerrainLayerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainLayer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainLayer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}