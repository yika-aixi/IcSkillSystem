//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:07
//Assembly-CSharp

using System;
using System.Collections;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class BuffEntity : MonoBehaviour,IEntity
    {
        public GameRoot Root;

        private IEntity _entity;

        public float HP;

        public IEntity Entity
        {
            get => _entity;
        }

        private void Start()
        {
            _entity = this;
            
#if UNITY_EDITOR
            //创建buff 连接来辅助调试
            var buffLink = gameObject.AddComponent<BuffEntityLinkComponent>();
            buffLink.Init(Root.BuffManager,_entity);
#endif
            
            Root.BuffManager.AddEntity(_entity);
            
            //当前生命
            Root.BuffManager.AddBuff(_entity,new MechanicBuff(MechanicsType.Health)
            {
                Value = HP
            });
            
            //最大生命
            Root.BuffManager.AddBuff(_entity,new MechanicBuff(MechanicsType.Health)
            {
                Value = HP
            });
        }

        public void MoveTarget(BuffEntity target)
        {
            StopCoroutine(_move(target));
            StartCoroutine(_move(target));
        }

        private IEnumerator _move(BuffEntity target)
        {
            while (Vector3.Distance(transform.position,target.transform.position) > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.2f);
                yield return null;
            }
        }
    }
}