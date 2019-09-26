using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/Tile Value")]
    public partial class TileValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.Tile _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.Tile);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}