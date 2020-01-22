using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScriptableObject Value")]
    public partial class ScriptableObjectValueNode:ValueNode<UnityEngine.ScriptableObject>
    {
        [SerializeField]
        private UnityEngine.ScriptableObject _value;
   
        protected override UnityEngine.ScriptableObject GetTValue()
        {
            return _value;
        }
    }
}