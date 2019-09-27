using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BoundingSphere Value")]
    public partial class BoundingSphereValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoundingSphere _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoundingSphere);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}