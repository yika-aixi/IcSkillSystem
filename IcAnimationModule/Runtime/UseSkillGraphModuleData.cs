//Create: Icarus
//ヾ(•ω•`)o
//2020-07-28 07:01
//CabinIcarus.IcSkillSystem.IcAnimationEditModule

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CabinIcarus.IcAnimationEditor.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;

[assembly: InternalsVisibleTo("CabinIcarus.IcSkillSystem.IcAnimationEditModule.Edit")]
namespace CabinIcarus.IcFrameWork.IcSkillSystem.IcAnimationModule.Runtime
{
    public class UseSkillGraphModuleData:ModuleData
    {
        [SerializeField] 
        internal IcSkillGraph _graph;
        
        private Queue<IcSkillGraph> _buffer = new Queue<IcSkillGraph>();

        public IcSkillGraph GetGraph(GameObject owner)
        {
            IcSkillGraph graph;
            
            if (_buffer.Count > 0)
            {
                graph = _buffer.Dequeue();
            }
            else
            {
                graph = (IcSkillGraph) _graph.Copy();
                graph.Owner = owner;
                graph.LoadGroup();
            }

            return graph;
        }

        public void StopGraph(IcSkillGraph graph)
        {
            graph.StopGroup();
            
            _buffer.Enqueue(graph);
        }
    }
}