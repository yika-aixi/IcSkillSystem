using NPBehave;
using UnityEngine;
using Action = NPBehave.Action;
namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Add or Remove")]
    public class AddOrRemoveBuffNode:ABuffNode
    {
        [SerializeField]
        private bool _isAddBuff = true;

        protected override Node Execute()
        {
            if (_isAddBuff)
            {
                return new Action(_addBuff);
            }
            
            return new Action(_removeBuff);
        }

        private void _removeBuff()
        {
            BuffFactory.RemoveBuff(EntityManager, Target,Buff);
        }

        private void _addBuff()
        {
            BuffFactory.AddBuff(EntityManager, Target,Buff);
        }
    }
}