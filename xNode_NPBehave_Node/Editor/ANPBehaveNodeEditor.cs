using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    public abstract class ANPBehaveNodeEditor<T,AT>: ANPNodeEditor<T,AT> where T : ANPNode<AT>
    {
        protected override void ColorCheck()
        {
            var NPBNodeInputs = TNode.Inputs.Where(x => typeof(Node).IsAssignableFrom(x.ValueType));

            foreach (var nodePort in NPBNodeInputs)
            {
                if (!nodePort.IsConnected)
                {
                    Error = true;
                }
            }
        }
    }
}