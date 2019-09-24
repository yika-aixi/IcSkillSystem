//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:30
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Systems;
using Random = UnityEngine.Random;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class Skill1System:ISkillExecuteSystem
    {
        private IBuffManager _buffManager;

        public Skill1System(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }
        
        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is Skill1;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            Skill1 sk = (Skill1) skill;
            
            _buffManager.AddBuff(entity,new DamageBuff()
            {
                Value = sk.Value,
                Type = sk.Type,
                Maker = sk.Maker
            });
        }
    }
    
    public class Skill2System:ISkillExecuteSystem
    {
        private IBuffManager _buffManager;

        public Skill2System(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }
        
        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is Skill2;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            Skill2 sk = (Skill2) skill;
            
            _buffManager.AddBuff(entity,new DamageBuff()
            {
                Value = sk.Value,
                Type = sk.Type,
                Maker = sk.Maker
            });
        }
    }
    
    public class Skill3System:ISkillExecuteSystem
    {
        private IBuffManager _buffManager;

        public Skill3System(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }
        
        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is Skill3;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            Skill3 sk = (Skill3) skill;

            var f = Random.Range(0,1f);
            if (f < sk.Probability)
            {
                _buffManager.AddBuff(entity,new ContinuousDamageBuff()
                {
                    Value = sk.Value,
                    Type = sk.Type,
                    Maker = sk.Maker,
                    Duration = sk.Duration,
                    TriggerInterval = sk.TriggerInterval,
                });
            }
            else
            {
                _buffManager.AddBuff(entity,new DamageBuff()
                {
                    Value = sk.Value,
                    Type = sk.Type,
                    Maker = sk.Maker
                });
            }
        }
    }
    
    public class Skill4System:ISkillExecuteSystem
    {
        private IBuffManager _buffManager;

        public Skill4System(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }
        
        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is Skill4;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            Skill4 sk = (Skill4) skill;
            
            _buffManager.AddBuff(entity,new DamageBuff()
            {
                Value = sk.Value,
                Maker = sk.Maker
            });
        }
    }
    
    public class Skill4AudioSystem:ISkillExecuteSystem
    {
        private readonly Action _playClip;

        public Skill4AudioSystem(Action playClip)
        {
            _playClip = playClip;
        }
        
        public bool Filter(IEntity entity, ISkillDataComponent skill)
        {
            return skill is Skill4;
        }

        public void Execute(IEntity entity, ISkillDataComponent skill)
        {
            _playClip();
        }
    }
}