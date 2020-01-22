using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Sprite Value")]
    public partial class SpriteValueNode:ValueNode<UnityEngine.Sprite>
    {
        [SerializeField]
        private UnityEngine.Sprite _value;
   
        protected override UnityEngine.Sprite GetTValue()
        {
            return _value;
        }
    }
}