using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicMaterial Value")]
    public partial class PhysicMaterialValueNode:ValueNode<UnityEngine.PhysicMaterial>
    {
        [SerializeField]
        private UnityEngine.PhysicMaterial _value;
   
        protected override UnityEngine.PhysicMaterial GetTValue()
        {
            return _value;
        }
    }
}