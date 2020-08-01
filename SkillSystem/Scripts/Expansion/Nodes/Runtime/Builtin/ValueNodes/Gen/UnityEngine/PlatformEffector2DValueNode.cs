using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PlatformEffector2D Value")]
    public partial class PlatformEffector2DValueNode:ValueNode<UnityEngine.PlatformEffector2D>
    {
        [SerializeField]
        private UnityEngine.PlatformEffector2D _value;
   
        protected override UnityEngine.PlatformEffector2D GetTValue()
        {
            return _value;
        }
    }
}