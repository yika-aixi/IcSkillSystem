using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Plane Value")]
    public partial class PlaneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Plane _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Plane);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}