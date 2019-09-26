using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TerrainData Value")]
    public partial class TerrainDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TerrainData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TerrainData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}