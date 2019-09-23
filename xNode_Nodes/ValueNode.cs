using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    /// <summary>
    /// 值节点,为了严格性,请在实现类在output一个实际类型,如IntNode
    /// </summary>
    public abstract class ValueNode:Node,ISkillSystemNode,IOutPutName
    {
        [SerializeField,Output()]
        [PortTooltip("值节点出口,如果你需要的是值请连接值出口")]
        private ValueNode _output;
        
        public abstract object Value { get; }

        public override object GetValue(NodePort port)
        {
            _output = this;
            return _output;
        }

        public string OutPutName { get; } = nameof(_output);
    }
}