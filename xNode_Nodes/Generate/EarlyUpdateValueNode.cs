using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/EarlyUpdate Value")]
    public partial class EarlyUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.EarlyUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.EarlyUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}