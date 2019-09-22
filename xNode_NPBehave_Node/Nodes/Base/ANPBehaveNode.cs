using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NPBehaveNode<T>:ANPBehaveNode<T> where T : NPBehaveNode<T>
    {
    }
}