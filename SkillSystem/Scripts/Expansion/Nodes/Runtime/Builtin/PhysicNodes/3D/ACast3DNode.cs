//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 11:16
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class ACast3DNode<T> : ACastNode<T>
    {
        [SerializeField]
        protected QueryTriggerInteraction TriggerInteraction;
    }
}