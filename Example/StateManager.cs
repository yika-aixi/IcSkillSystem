//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-22:26
//Assembly-CSharp

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class StateManager : MonoBehaviour
    {
        public Scrollbar Player1_HP, 
                         Player2_HP;

        public Transform Player1_Buff,
                         Player2_Buff;

        public Sprite[] Icons;
        
        private Dictionary<IEntity, Dictionary<Type, List<GameObject>>> _buffIconMaps;

        public Dictionary<IEntity, int> _entityIndex;

        private int _lastIndex;
        
        private void Awake()
        {
            _buffIconMaps = new Dictionary<IEntity, Dictionary<Type, List<GameObject>>>();
            _entityIndex = new Dictionary<IEntity, int>();
        }

        public void AddEntity(IEntity entity)
        {
            if (!_entityIndex.ContainsKey(entity))
            {
                ++_lastIndex;
                _entityIndex.Add(entity,_lastIndex);
            }
        }

        public void AddBuffIcon(IEntity entity, IBuffDataComponent buff,Sprite iconSprite)
        {
            AddEntity(entity);
            
            if (!_buffIconMaps.ContainsKey(entity))
            {
                _buffIconMaps.Add(entity,new Dictionary<Type, List<GameObject>>());
                
                _buffIconMaps[entity].Add(buff.GetType(),new List<GameObject>());
            }

            GameObject icon = new GameObject();

            if (buff is IBuffDescriptionComponent descriptionComponent)
            {
                var buffDe = icon.AddComponent<BuffDesCom>();
                buffDe.buffName = descriptionComponent.Name;
                buffDe.BuffDes = descriptionComponent.Description;
            }

            var image = icon.AddComponent<Image>();

            image.sprite = iconSprite;

            var index = _entityIndex[entity];

            if (index == 1)
            {
                icon.transform.SetParent(Player1_Buff,false);
            }
            else
            {
                icon.transform.SetParent(Player2_Buff,false);
            }
            
            _buffIconMaps[entity][buff.GetType()].Add(icon);
        }

        public void RemoveBuffIcon(IEntity entity, IBuffDataComponent buff)
        {
            if (!_buffIconMaps.ContainsKey(entity))
            {
                return;
            }
            
            if (!_buffIconMaps[entity].ContainsKey(buff.GetType()))
            {
                return;
            }

            if (_buffIconMaps[entity][buff.GetType()].Count == 0)
            {
                return;
            }
            
            var buffGO = _buffIconMaps[entity][buff.GetType()][0];
            Destroy(buffGO);
            _buffIconMaps[entity][buff.GetType()].RemoveAt(0);
        }

        public Scrollbar GetPlayerHPBar(IEntity entity)
        {
             AddEntity(entity);
            //todo 不管了, Key
            return _entityIndex[entity] == 1 ? Player1_HP : Player2_HP;
        }
    }
    
    public class BuffDesCom : MonoBehaviour
    {
        public string buffName;
        public string BuffDes;
    }

    #region Buff Icon

    public abstract class ABuffIconShowSystem:IBuffCreateSystem,IBuffDestroySystem
    {
        protected readonly StateManager StateManager;

        public ABuffIconShowSystem(StateManager stateManager)
        {
            StateManager = stateManager;
        }

        public abstract bool Filter(IEntity entity, IBuffDataComponent buff);

        public void Destroy(IEntity entity, IBuffDataComponent buff)
        {
            StateManager.RemoveBuffIcon(entity,buff);
        }

        protected abstract Sprite GetSprite();

        public void Create(IEntity entity, IBuffDataComponent buff)
        {
            StateManager.AddBuffIcon(entity,buff,GetSprite());
        }
    }
    
    public class DamageReduceFixedBuffIconShowSystem:ABuffIconShowSystem
    {
        public DamageReduceFixedBuffIconShowSystem(StateManager stateManager) : base(stateManager)
        {
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageReduceFixedBuff;
        }

        protected override Sprite GetSprite()
        {
            return StateManager.Icons[0];
        }
    }
    
    public class DamageReducePercentageShowSystem:ABuffIconShowSystem
    {
        public DamageReducePercentageShowSystem(StateManager stateManager) : base(stateManager)
        {
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageReducePercentageBuff;
        }

        protected override Sprite GetSprite()
        {
            return StateManager.Icons[1];
        }
    }
    
    public class ContinuousDamageBuffShowSystem:ABuffIconShowSystem
    {
        public ContinuousDamageBuffShowSystem(StateManager stateManager) : base(stateManager)
        {
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IContinuousDamageBuff;
        }

        protected override Sprite GetSprite()
        {
            return StateManager.Icons[2];
        }
    }
    
    #endregion


    public class HPBarChanageSystem:ABuffDestroySystem,IBuffCreateSystem
    {
        private readonly StateManager _stateManager;
        private List<IMechanicBuff> _buffs;
        public HPBarChanageSystem(IBuffManager buffManager,StateManager stateManager) : base(buffManager)
        {
            _stateManager = stateManager;
            _buffs = new List<IMechanicBuff>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            //1.伤害buff同时存在生命值buff
            //2.创建生命buff
            return buff is IDamageBuff &&
                   BuffManager.HasBuff<IMechanicBuff>(entity, x => x.MechanicsType == MechanicsType.Health) ||
                   buff is IMechanicBuff mBuff && mBuff.MechanicsType == MechanicsType.Health;
        }

        public void Create(IEntity entity, IBuffDataComponent buff)
        {
            var HpBar = _stateManager.GetPlayerHPBar(entity);
            HpBar.size = 1;
        }

        public override void Destroy(IEntity entity, IBuffDataComponent buff)
        {
            if (buff is IDamageBuff)
            {
                var HpBar = _stateManager.GetPlayerHPBar(entity);

                BuffManager.GetBuffs(entity, x => x.MechanicsType == MechanicsType.Health,_buffs);
            
                var hp1 = _buffs[0];
                var hp2 = _buffs[1];
                HpBar.size = hp1.Value / (float) hp2.Value;
            }
        }
    }
    
}