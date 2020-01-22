using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/String Value")]
    public partial class StringValueNode:ValueNode<System.String>
    {
        [SerializeField]
        private System.String _value;
   
        protected override System.String GetTValue()
        {
            return _value;
        }
    }
}