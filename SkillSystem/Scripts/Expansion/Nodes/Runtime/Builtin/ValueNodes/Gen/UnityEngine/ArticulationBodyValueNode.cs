using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationBody Value")]
    public partial class ArticulationBodyValueNode:ValueNode<UnityEngine.ArticulationBody>
    {
        [SerializeField]
        private UnityEngine.ArticulationBody _value;
   
        protected override UnityEngine.ArticulationBody GetTValue()
        {
            return _value;
        }
    }
}