using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NUnit.Framework;
using UnityEngine.TestTools;
using Debug = UnityEngine.Debug;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class NewBuffManagerTest
    {
        struct Buff:IBuffDataComponent,IBuffValueDataComponent
        {
            public float Value { get; set; }
        }
        
        ref struct Test
        {
            public int a;
        }
        
        
        [Test]
        public void RefStructTest()
        {
            Test t = new Test();

            t.a = 100;

            Test t1 = t;

            t.a = 20;
            
            Assert.GreaterOrEqual(t1.a,20);
        }
        
        [Test]
        public void 简单的添加Buff()
        {
            NewBuffManager buffManager = new NewBuffManager();

            BuffEntity entity = new BuffEntity();
            buffManager.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            buffManager.AddBuff(entity,new Buff(){});
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed} {stop.Elapsed.Milliseconds}");
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),1);
        }
        
        [Test]
        public void 添加Buff_10001()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity();
            buffManager.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManager.AddBuff(entity,new Buff(){});
            }
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),10001);
        }
        
        [Test]
        public void 添加Buff_10001_查找Value为0的()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity();
            buffManager.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManager.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),10001);

            stop.Restart();

            var result = buffManager.GetBuffs(entity, new Buff() {Value = 0});
            
            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");

            Assert.GreaterOrEqual(result.Count(),2001);
        }

        class TestSystem:AIcStructBuffSystem
        {
//            private readonly NewBuffManager _buffManager;
//
//
//            public TestSystem(NewBuffManager buffManager)
//            {
//                this._buffManager = buffManager;
//            }

            public override void Create(BuffEntity entity, int index)
            {
                Debug.Log("1");
//                var buff = _buffManager.GetCurrentBuffData<Buff>(index);
////                var buff = _buffManager.GetBuffData<Buff>(entity, index);
//                if ((int)buff.Value == 0)
//                {
//                    _buffManager.SetBuffData(entity,new Buff(){Value = 100}, index);
//                }
            }

            public TestSystem(INewBuffManager<AIcStructBuffSystem> buffManager) : base(buffManager)
            {
            }
        }
        
        class TestSystem1:AIcStructBuffSystem
        {
//            private readonly NewBuffManager _buffManager;
//
//
//            public TestSystem1(NewBuffManager buffManager)
//            {
//                this._buffManager = buffManager;
//            }

            public override void Create(BuffEntity entity, int index)
            {
                Debug.Log("2");
//                var buff = _buffManager.GetCurrentBuffData<Buff>(index);
////                var buff = _buffManager.GetBuffData<Buff>(entity, index);
//                if ((int)buff.Value == 0)
//                {
//                    _buffManager.SetBuffData(entity,new Buff(){Value = 100}, index);
//                }
            }

            public TestSystem1(INewBuffManager<AIcStructBuffSystem> buffManager) : base(buffManager)
            {
            }
        }
        
        [Test]
        public void 添加Buff_10001_Value为0的将他们修改为100()
        {
            NewBuffManager buffManager = new NewBuffManager();
            for (var i = 0; i < 100; i++)
                buffManager.AddBuffSystem(new TestSystem(new NewBuffManager()))
                    .AddBuffSystem(new TestSystem1(buffManager));
            BuffEntity entity = new BuffEntity();
            buffManager.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 1; i++)
            {
                buffManager.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            //Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),10001);

            stop.Restart();

            var result = buffManager.GetBuffs(entity, new Buff() {Value = 100});
            
            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");

            //Assert.GreaterOrEqual(result.Count(),2001);
        }
        
        [Test]
        public void 简单的添加删除Buff()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity();
            buffManager.AddEntity(entity);

            var buff = new Buff(){};
            
            buffManager.AddBuff(entity,buff);
            buffManager.RemoveBuff(entity,buff);
            
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),0);
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator NewBuffManagerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // yield to skip a frame
            yield return null;
        }

        class CB:IBuffDataComponent
        {
            
        }
        [Test]
        public void TestT()
        {    
            IStructBuffManager<AIcStructBuffSystem> t1 = new NewBuffManager();
            
            IStructBuffManager<AIcStructBuffSystem> t2 = new NewBuffManager();
            
            NewBuffManager t3 = new NewBuffManager();
            
            BuffEntity entity = new BuffEntity();
            
            Buff buff = new Buff();
            
            t1.AddEntity(entity);
            t1.AddBuff(entity,buff);
            
            t2.AddEntity(entity);
            t3.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            t2.AddBuff(entity, buff);
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed}");
            
            stop.Restart();
            t3.AddBuff(entity, buff);
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed}");
            
            var count =t1.GetBuffCount<Buff>(entity);
            
            Debug.Log(count);
        }
    }
}