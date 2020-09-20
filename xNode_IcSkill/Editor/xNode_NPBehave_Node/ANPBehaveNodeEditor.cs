using System.Linq;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;

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
            
            var mustInputs = TNode.Inputs.Where(x => x.GetType().GetCustomAttribute<MustInputAttribute>() != null);

            foreach (var nodePort in mustInputs)
            {
                if (!nodePort.IsConnected)
                {
                    Error = true;
                }
            }
        }
    }
}