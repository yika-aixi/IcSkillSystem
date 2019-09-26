using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TilemapModule/TilemapRenderer Value")]
    public partial class TilemapRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tilemaps.TilemapRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tilemaps.TilemapRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}