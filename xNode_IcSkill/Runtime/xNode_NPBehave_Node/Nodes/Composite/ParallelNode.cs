//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-19:30
//Assembly-CSharp

using System.Collections.Generic;
using System.Linq;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Composite
{
    [XNode.Node.CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Composite/Parallel")]
    public class ParallelNode:ACompositeNode<Parallel>
    {
        [SerializeField]
        private Parallel.Policy _successPolicy;
        
        [SerializeField]
        private Parallel.Policy _failurePolicy;

        protected override Parallel GetNode(IEnumerable<Node> inputNodes)
        {
            return new Parallel(_successPolicy,_failurePolicy,inputNodes.ToArray());
        }
    }
}