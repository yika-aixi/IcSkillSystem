using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/Terrain Value")]
    public partial class TerrainValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Terrain _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Terrain);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}