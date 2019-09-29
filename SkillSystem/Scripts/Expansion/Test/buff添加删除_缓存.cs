using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEngine;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class buff添加删除_缓存 : MonoBehaviour
    {
        private BuffManager _buffManage;
        private Enity _entity;
        
        private void Start()
        {
            _buffManage = new BuffManager();
            _entity = new Enity();
            
            _buffAddAndRemove();

            GameObject go = new GameObject();

            var buffL = go.AddComponent<BuffEntityLinkComponent>();
        
            buffL.Init(_buffManage,_entity);
        
        }

        [ContextMenu("Add")]
        private void _buffAdd()
        {
            var type = typeof(TestBuff);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type, _entity, x => { ((TestBuff) x).name = i1.ToString(); });
            }
        }
        
        [ContextMenu("Add And Remove")]
        private void _buffAddAndRemove()
        {
            var type = typeof(TestBuff);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type, _entity, x => { ((TestBuff) x).name = i1.ToString(); });
                _buffManage.RemoveBuffEx(_entity, buff);
            }
        }
    }
}