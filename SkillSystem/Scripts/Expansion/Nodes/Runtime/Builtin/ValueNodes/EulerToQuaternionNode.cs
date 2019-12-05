//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月19日-22:50
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Euler To Quaternion Value")]
    public class EulerToQuaternionNode:ValueNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [SerializeField]
        private Vector3 _euler;
        
        public override Type ValueType { get; } = typeof(Quaternion);
        
        protected override object GetOutValue()
        {
            return Quaternion.Euler(GetInputValue(nameof(_euler), _euler));
        }
    }
}