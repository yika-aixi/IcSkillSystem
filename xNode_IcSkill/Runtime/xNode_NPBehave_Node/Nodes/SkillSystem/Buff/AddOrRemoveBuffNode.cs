using NPBehave;
using UnityEngine;
using Action = NPBehave.Action;
namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Add or Remove")]
    public class AddOrRemoveBuffNode:ABuffNode<Action>
    {
        [SerializeField]
        private bool _isAddBuff = true;

        private IBuffDataComponent _buff;
        
        protected override Action Execute()
        {
            if (BuffType == null)
            {
                return null;
            }
            
            _buff = (IBuffDataComponent) this.DynamicInputCreateInstance(BuffType);
            
            if (_isAddBuff)
            {
                return () => BuffManager.AddBuff(Target, _buff);
            }
            
            return () => BuffManager.RemoveBuff(Target,_buff);
        }
    }
}