using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Transform Value")]
    public partial class TransformValueNode:ValueNode<UnityEngine.Transform>
    {
        [SerializeField]
        private UnityEngine.Transform _value;
   
        protected override UnityEngine.Transform GetTValue()
        {
            return _value;
        }
    }
}