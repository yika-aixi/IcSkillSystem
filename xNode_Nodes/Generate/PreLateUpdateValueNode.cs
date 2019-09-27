using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PreLateUpdate Value")]
    public partial class PreLateUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.PreLateUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.PreLateUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}