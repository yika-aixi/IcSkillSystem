using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/ReactorModel Value")]
    public partial class ReactorModelValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.ReactorModel _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.ReactorModel);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}