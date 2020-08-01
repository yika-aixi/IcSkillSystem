using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Physics Value")]
    public partial class PhysicsValueNode:ValueNode<UnityEngine.Physics>
    {
        [SerializeField]
        private UnityEngine.Physics _value;
   
        protected override UnityEngine.Physics GetTValue()
        {
            return _value;
        }
    }
}