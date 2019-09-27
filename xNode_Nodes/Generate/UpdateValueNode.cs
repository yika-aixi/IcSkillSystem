using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Update Value")]
    public partial class UpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.Update _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.Update);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}