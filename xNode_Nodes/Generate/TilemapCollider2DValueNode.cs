using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/TilemapCollider2D Value")]
    public partial class TilemapCollider2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.TilemapCollider2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.TilemapCollider2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}