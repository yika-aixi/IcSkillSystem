using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SurfaceEffector2D Value")]
    public partial class SurfaceEffector2DValueNode:ValueNode<UnityEngine.SurfaceEffector2D>
    {
        [SerializeField]
        private UnityEngine.SurfaceEffector2D _value;
   
        protected override UnityEngine.SurfaceEffector2D GetTValue()
        {
            return _value;
        }
    }
}