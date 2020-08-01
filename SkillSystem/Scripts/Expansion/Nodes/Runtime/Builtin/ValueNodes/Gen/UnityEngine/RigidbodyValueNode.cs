using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Rigidbody Value")]
    public partial class RigidbodyValueNode:ValueNode<UnityEngine.Rigidbody>
    {
        [SerializeField]
        private UnityEngine.Rigidbody _value;
   
        protected override UnityEngine.Rigidbody GetTValue()
        {
            return _value;
        }
    }
}