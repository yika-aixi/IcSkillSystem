using System;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    public class SystemObjectNode:ValueNode
    {
        public const string InputValuePortName = "InputValuePort";
        
        public override Type ValueType { get; } = typeof(object);

        public override bool IsChangeValueType { get; } = true;
        
        protected override object GetOutValue()
        {
            return GetInputValue<object>(InputValuePortName);
        }
    }
}