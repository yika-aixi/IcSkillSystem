using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/TileAnimationData Value")]
    public partial class TileAnimationDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.TileAnimationData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.TileAnimationData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}