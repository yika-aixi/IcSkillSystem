using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/Tilemap Value")]
    public partial class TilemapValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.Tilemap _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.Tilemap);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}