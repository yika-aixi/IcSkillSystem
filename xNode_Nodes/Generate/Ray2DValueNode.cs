using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Ray2D Value")]
    public partial class Ray2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Ray2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Ray2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}