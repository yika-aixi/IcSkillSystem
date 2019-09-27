using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/TileData Value")]
    public partial class TileDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.TileData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.TileData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}