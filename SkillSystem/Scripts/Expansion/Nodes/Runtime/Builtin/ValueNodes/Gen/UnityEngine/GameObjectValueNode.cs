using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GameObject Value")]
    public partial class GameObjectValueNode:ValueNode<UnityEngine.GameObject>
    {
        [SerializeField]
        private UnityEngine.GameObject _value;
   
        protected override UnityEngine.GameObject GetTValue()
        {
            return _value;
        }
    }
}