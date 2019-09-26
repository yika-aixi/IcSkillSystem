using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/TileFlags Value")]
    public partial class TileFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.TileFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.TileFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}