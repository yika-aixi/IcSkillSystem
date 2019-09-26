using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/GridLayoutGroup Value")]
    public partial class GridLayoutGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.GridLayoutGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.GridLayoutGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}