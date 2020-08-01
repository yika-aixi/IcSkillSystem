using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConstantForce Value")]
    public partial class ConstantForceValueNode:ValueNode<UnityEngine.ConstantForce>
    {
        [SerializeField]
        private UnityEngine.ConstantForce _value;
   
        protected override UnityEngine.ConstantForce GetTValue()
        {
            return _value;
        }
    }
}