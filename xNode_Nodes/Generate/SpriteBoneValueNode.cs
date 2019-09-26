using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteBone Value")]
    public partial class SpriteBoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.SpriteBone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.SpriteBone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}