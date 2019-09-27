using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2Int Value")]
    public partial class Vector2IntValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Vector2Int _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Vector2Int);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}