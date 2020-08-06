using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/BuoyancyEffector2D Value")]
    public partial class BuoyancyEffector2DValueNode:ValueNode<UnityEngine.BuoyancyEffector2D>
    {
        [SerializeField]
        private UnityEngine.BuoyancyEffector2D _value;
   
        protected override UnityEngine.BuoyancyEffector2D GetTValue()
        {
            return _value;
        }
    }
}