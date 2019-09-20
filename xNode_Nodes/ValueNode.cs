using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    public abstract class ValueNode<T>:Node,ISkillSystemNode
    {
        [SerializeField,Output(ShowBackingValue.Always,ConnectionType.Multiple)]
        private T _value;

        public override object GetValue(NodePort port)
        {
            return _value;
        }
    }
}