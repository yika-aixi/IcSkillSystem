using System.Collections;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class StructBuffManagerTest
    {
        class buff1:IBuffDataComponent
        {
            
        }

        struct buff2:IBuffDataComponent
        {
            
        }
        
        struct buff3:IBuffDataComponent
        {
            public int a;
            public int b { get; set; }
        }
        
        struct buff4:IBuffDataComponent
        {
            public int a;
            public string b;
        }
        
        struct buff5:IBuffDataComponent
        {
            public int a;
            public string b { get; set; }
        }
        
        struct buff6:IBuffDataComponent
        {
            public int a;
            private string b;
        }
        
        struct buff7:IBuffDataComponent
        {
            public int a;
            private string b { get; set; }
        }
        
        [Test]
        public void 类buff创建不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var exception = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff1()); });

            if (!exception.Message.Contains("not is Struct Type"))
            {
                Assert.Fail();
            }
            Debug.Log(exception.Message);
        }
        
        [Test]
        public void 空结构buff创建()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();
            structBuffManager.AddBuff(new Enity(), new buff2());
        }
        
        [Test]
        public void 结构值字段buff()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();
            structBuffManager.AddBuff(new Enity(), new buff3());
        }
        
        [Test]
        public void 结构含引用字段buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff4()); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含引用属性buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff5()); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含私有引用字段buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff6()); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含私有引用属性buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff7()); });
            
            Debug.Log(ex.Message);
        }
    }
}