using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Joint2D Value")]
    public partial class Joint2DValueNode:ValueNode<UnityEngine.Joint2D>
    {
        [SerializeField]
        private UnityEngine.Joint2D _value;
   
        protected override UnityEngine.Joint2D GetTValue()
        {
            return _value;
        }
    }
}