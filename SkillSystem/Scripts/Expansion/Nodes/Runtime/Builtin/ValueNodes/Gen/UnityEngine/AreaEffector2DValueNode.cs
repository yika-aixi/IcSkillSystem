using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/AreaEffector2D Value")]
    public partial class AreaEffector2DValueNode:ValueNode<UnityEngine.AreaEffector2D>
    {
        [SerializeField]
        private UnityEngine.AreaEffector2D _value;
   
        protected override UnityEngine.AreaEffector2D GetTValue()
        {
            return _value;
        }
    }
}