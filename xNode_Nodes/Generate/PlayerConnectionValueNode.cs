using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayerConnection Value")]
    public partial class PlayerConnectionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.PlayerConnection.PlayerConnection _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.PlayerConnection.PlayerConnection);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}