using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using NUnit.Framework;
using UnityEngine.TestTools;
using Debug = UnityEngine.Debug;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class Enity:IEntity
    {
    }

    public class TestBuff : IBuffDataComponent
    {
        public string name;

        public override string ToString()
        {
            return $"Name: {name}";
        }
    }
    public class BuffManagerTest
    {
        private BuffManager _buffManage;
        private Enity _entity;
        private long _startMemory;
        private long _endMemory;
        
        
        public BuffManagerTest()
        {
            _buffManage = new BuffManager();
        }


        [SetUp]
        public void Init()
        {
            _entity = new Enity();
        }

        [TearDown]
        public void End()
        {
//            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
        }

        void _setEndMemory()
        {
            _endMemory = GC.GetTotalMemory(false);
        }
        
        [Test()]
        public void 添加buff_引用缓存()
        {
            var type = typeof(TestBuff);
            _startMemory = GC.GetTotalMemory(false);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                _buffManage.CreateAndAddBuff(type,_entity, /*x => { ((TestBuff) x).name = i1.ToString();}*/null);
            }
            _setEndMemory();
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(buffs.Count,5000);
        }
        List<TestBuff> _testBuffs = new List<TestBuff>();
        [Test()]
        public void 添加buff_1()
        {
            _startMemory = GC.GetTotalMemory(false);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            _testBuffs.Add(new TestBuff());
            stop.Stop();
            _setEndMemory();
            Debug.Log($"Time:{stop.Elapsed}");
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(_testBuffs.Count,1);
        }
        
        [Test()]
        public void 添加buff()
        {
            _startMemory = GC.GetTotalMemory(false);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (int i = 0; i < 5000; i++)
            {
                _buffManage.AddBuff(_entity,new TestBuff(){/*name = i.ToString()*/});
            }
            stop.Stop();
            _setEndMemory();
            Debug.Log($"Time:{stop.Elapsed}");
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(buffs.Count,5000);
        }

        public struct TestS:IBuffDataComponent
        {
        }
        
        [Test()]
        public void 添加buff_Struct()
        {
            _startMemory = GC.GetTotalMemory(false);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (int i = 0; i < 5000; i++)
            {
                _buffManage.AddBuff(_entity,new TestS());
            }
            stop.Stop();
            _setEndMemory();
            Debug.Log($"Time:{stop.Elapsed}");
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(buffs.Count,5000);
        }
        
        [Test()]
        public void 添加buff并删除_引用缓存()
        {
            var type = typeof(TestBuff);
            _startMemory = GC.GetTotalMemory(false);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type,_entity,/*x => { ((TestBuff) x).name = i1.ToString();}*/null);
                _buffManage.RemoveBuffEx(_entity,buff);
            }
            _setEndMemory();
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(buffs.Count,0);
        }
        
        [Test()]
        public void 添加buff并删除()
        {
            _startMemory = GC.GetTotalMemory(false);

            for (int i = 0; i < 5000; i++)
            {
                var buffDataComponent = new TestBuff()/*{name = i.ToString()}*/;
                _buffManage.AddBuff(_entity,buffDataComponent);
                _buffManage.RemoveBuff(_entity,buffDataComponent);
            }
            _setEndMemory();
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
            List<IBuffDataComponent> buffs = new List<IBuffDataComponent>();
            _buffManage.GetBuffs(_entity, buffs);
            
            Assert.GreaterOrEqual(buffs.Count,0);
        }
    }
}