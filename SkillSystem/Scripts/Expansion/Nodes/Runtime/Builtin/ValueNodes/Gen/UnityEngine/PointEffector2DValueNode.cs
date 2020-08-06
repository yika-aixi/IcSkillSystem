using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PointEffector2D Value")]
    public partial class PointEffector2DValueNode:ValueNode<UnityEngine.PointEffector2D>
    {
        [SerializeField]
        private UnityEngine.PointEffector2D _value;
   
        protected override UnityEngine.PointEffector2D GetTValue()
        {
            return _value;
        }
    }
}