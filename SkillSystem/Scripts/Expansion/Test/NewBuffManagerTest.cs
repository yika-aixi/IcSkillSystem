using System.Collections;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class NewBuffManagerTest
    {
        struct Buff:IBuffDataComponent,IBuffValueDataComponent
        {
            public float Value { get; set; }
        }
        
        [Test]
        public void 简单的添加Buff()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity(){ID = 1};
            
            buffManager.AddBuff(entity,new Buff(){Value = 20f});
            
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),1);
        }
        
        [Test]
        public void 添加Buff_10001()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity(){ID = 1};
            
            for (var i = 0; i < 10001; i++)
            {
                buffManager.AddBuff(entity,new Buff(){Value = 20f+i});
            }
            
            Assert.GreaterOrEqual(buffManager.GetBuffCount<Buff>(entity),10001);
        }
        
        [Test]
        public void 简单的添加删除Buff()
        {
            NewBuffManager buffManager = new NewBuffManager();
            BuffEntity entity = new BuffEntity(){ID = 1};

            var buff = new Buff(){Value = 20f};
            
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
    }
}