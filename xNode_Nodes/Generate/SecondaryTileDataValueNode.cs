using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SecondaryTileData Value")]
    public partial class SecondaryTileDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.SecondaryTileData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.SecondaryTileData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}