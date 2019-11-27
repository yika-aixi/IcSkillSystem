using System.Linq;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    public abstract class ANPBehaveNodeEditor<T,AT>: ANPNodeEditor<T,AT> where T : ANPBehaveNode<AT> where AT : Node
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