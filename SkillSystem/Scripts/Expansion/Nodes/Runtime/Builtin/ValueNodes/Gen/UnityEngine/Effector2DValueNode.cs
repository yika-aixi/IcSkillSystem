using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Effector2D Value")]
    public partial class Effector2DValueNode:ValueNode<UnityEngine.Effector2D>
    {
        [SerializeField]
        private UnityEngine.Effector2D _value;
   
        protected override UnityEngine.Effector2D GetTValue()
        {
            return _value;
        }
    }
}