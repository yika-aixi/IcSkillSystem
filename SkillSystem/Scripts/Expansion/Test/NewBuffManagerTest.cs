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
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();

            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            buffManagerStruct.AddBuff(entity,new Buff(){});
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed} {stop.Elapsed.Milliseconds}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),1);
        }
        
        [Test]
        public void 添加Buff_10001()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManagerStruct.AddBuff(entity,new Buff(){});
            }
            stop.Stop();
            Debug.Log($"Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),10001);
        }
        
        [Test]
        public void 添加Buff_10001_查找Value为0的()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            buffManagerStruct.GetBuffsCondition<Buff>(entity, null);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManagerStruct.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),10001);

            stop.Restart();

            var result = buffManagerStruct.GetBuffsCondition<Buff>(entity, x=> (int) x.Value == 0);

            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");

#if ENABLE_MANAGED_JOBS
            Assert.GreaterOrEqual(result.Length,2001);
#else
            Assert.GreaterOrEqual(result.Count,2001);
#endif
        }
        
        [Test]
        public void 添加Buff_10001_查找Value为0的_Out()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            buffManagerStruct.GetBuffsCondition<Buff>(entity, null,out _);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManagerStruct.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),10001);

            FasterList<Buff> _result;
            stop.Restart();

            var result = buffManagerStruct.GetBuffsCondition(entity, x=> (int) x.Value == 0,out _result);

            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");

#if ENABLE_MANAGED_JOBS
            Assert.GreaterOrEqual(result.Length,2001);
#else
            Assert.GreaterOrEqual(result.Count,2001);
#endif
        }

        class TestSystem:AIcStructBuffSystem<IcSkSEntity,Buff>
        {

            public override void Create(IcSkSEntity entity, int index)
            {
                var buff = BuffManager.GetCurrentBuffData<Buff>(index);
                if ((int)buff.Value == 0)
                {
                    BuffManager.SetBuffData(entity,new Buff(){Value = 100}, index);
                }
            }

            public TestSystem(IStructBuffManager<IcSkSEntity> buffManager) : base(buffManager)
            {
            }
        }

        
        [Test]
        public void 添加Buff_10001和一个处理系统_Value为0的将他们修改为100()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            buffManagerStruct.AddBuffSystem<Buff>(new TestSystem(buffManagerStruct));
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            buffManagerStruct.GetBuffsCondition<Buff>(entity, null);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManagerStruct.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),10001);

            stop.Restart();

            var result = buffManagerStruct.GetBuffsCondition<Buff>(entity, x=> (int) x.Value == 100);
            
            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");
            
#if ENABLE_MANAGED_JOBS
            Assert.GreaterOrEqual(result.Length,2001);
#else
            Assert.GreaterOrEqual(result.Count,2001);
#endif
        }
        
          [Test]
        public void 添加Buff_10001_Value为0的将他们修改为100_Out()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);
            buffManagerStruct.GetBuffsCondition<Buff>(entity, null,out _);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            for (var i = 0; i < 10001; i++)
            {
                buffManagerStruct.AddBuff(entity,new Buff(){Value = i % 5});
            }
            stop.Stop();
            Debug.Log($"Add Time:{stop.Elapsed}");
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),10001);

            stop.Restart();

            var result = buffManagerStruct.GetBuffsCondition<Buff>(entity, x=> (int) x.Value == 0,out var buffs);
            
            foreach (var i in result)
            {
                buffs[i].Value = 100;
            }
            
            stop.Stop();
            Debug.Log($"Find Time:{stop.Elapsed}");
            
            result = buffManagerStruct.GetBuffsCondition<Buff>(entity, x=> (int) x.Value == 100,out _);
#if ENABLE_MANAGED_JOBS
            Assert.GreaterOrEqual(result.Length,2001);
#else
            Assert.GreaterOrEqual(result.Count,2001);
#endif
        }
        
        [Test]
        public void 简单的添加删除Buff()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);

            var buff = new Buff(){};
            
            buffManagerStruct.AddBuff(entity,buff);
            buffManagerStruct.RemoveBuff(entity,buff);
            
            Assert.GreaterOrEqual(buffManagerStruct.GetBuffCount<Buff>(entity),0);
        }
        
        [Test]
        public void 简单的添加修改Buff_正常()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);

            var buff = new Buff(){};
            
            buffManagerStruct.AddBuff(entity,buff);
            buffManagerStruct.SetBuffData(entity,new Buff(){Value = 100}, 0);

            Assert.GreaterOrEqual(buffManagerStruct.GetBuffData<Buff>(entity,0).Value, 100);
        }
        
        [Test]
        public void 简单的添加修改Buff_BOX()
        {
            BuffManager_Struct buffManagerStruct = new BuffManager_Struct();
            IcSkSEntity entity = new IcSkSEntity();
            buffManagerStruct.AddEntity(entity);

            var buff = new Buff(){};

            buffManagerStruct.AddBuff(entity,buff);

            IBuffManager<IcSkSEntity> b = buffManagerStruct;
            
            b .SetBuffData(entity,new Buff(){Value = 100}, 0);

            Assert.GreaterOrEqual(b.GetBuffData<Buff>(entity,0).Value, 100);
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
    }
}