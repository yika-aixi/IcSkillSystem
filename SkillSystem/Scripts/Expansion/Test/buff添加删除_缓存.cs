using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEngine;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class buff添加删除_缓存 : MonoBehaviour
    {
        private BuffManager _buffManage;
        private StructBuffManager _structBuffManage;
        private Enity _entity;
        
        private void Start()
        {
            _buffManage = new BuffManager();
            _structBuffManage = new StructBuffManager();
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
                var buff = _buffManage.CreateAndAddBuff(type, _entity, /*x => { ((TestBuff) x).name = i1.ToString(); }*/null);
            }
        }
        
        [ContextMenu("Add And Remove")]
        private void _buffAddAndRemove()
        {
            var type = typeof(TestBuff);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type, _entity, /*x => { ((TestBuff) x).name = i1.ToString(); }*/null);
                _buffManage.RemoveBuffEx(_entity, buff);
            }
        }

        public bool _isStruct = true;
        
        public bool IsAdd;
        public bool IsRemove;
        
        private List<BuffManagerTest.TestS> _bufs = new  List<BuffManagerTest.TestS>();
        private List<TestBuff> _bufss = new  List<TestBuff>();
        private void Update()
        {
            if (_isStruct)
            {
                if (IsAdd)
                {
                    var testS = new BuffManagerTest.TestS();
                    _bufs.Add(testS);
                    _structBuffManage.AddBuff(_entity,testS);
                }

                if (IsRemove)
                {
                    _structBuffManage.RemoveBuff(_entity,_bufs[_bufs.Count - 1]);
                }
            }
            else
            {
                if (IsAdd)
                {
                    var testS = new TestBuff();
                    _bufss.Add(testS);
                    _buffManage.AddBuff(_entity,testS);
                }

                if (IsRemove)
                {
                    _buffManage.RemoveBuff(_entity,_bufss[_bufss.Count - 1]);
                }
            }
           
        }
    }
}