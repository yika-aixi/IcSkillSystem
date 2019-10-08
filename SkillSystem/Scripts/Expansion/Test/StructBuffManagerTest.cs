using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Buffs.Exceptions;
using NUnit.Framework;
using UnityEngine;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class StructBuffManagerTest
    {
        static int _getCurrentMilliSeconds()
        {
            return (int) (DateTime.Now.Ticks / 10000L % 1000L);
        }
        
        class buff1:IStructBuffDataComponent
        {
            public int ID { get; } = _getCurrentMilliSeconds();
        }

        struct buff2:IStructBuffDataComponent
        {
            public buff2(int id)
            {
                ID = id;
            }

            public int ID { get; }

        }
        
        struct buff3:IStructBuffDataComponent
        {
            public int a;
            public int b { get; set; }
            public int ID { get; }

            public buff3(int id) : this()
            {
                ID = id;
            }
        }
        
        struct buff4:IStructBuffDataComponent
        {
            public int a;
            public string b;
            public int ID { get; }

            public buff4(int id) : this()
            {
                ID = id;
            }
        }
        
        struct buff5:IStructBuffDataComponent
        {
            public int a;
            public string b { get; set; }
            public int ID { get; }

            public buff5(int id) : this()
            {
                ID = id;
            }
        }
        
        struct buff6:IStructBuffDataComponent
        {
            public int a;
            private string b;
            public int ID { get; }

            public buff6(int id) : this()
            {
                ID = id;
            }
        }
        
        struct buff7:IStructBuffDataComponent
        {
            public int a;
            private string b { get; set; }
            public int ID { get; }

            public buff7(int id) : this()
            {
                ID = id;
            }
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
            addBuff(structBuffManager, new buff2(_getCurrentMilliSeconds()));
        }

        private void addBuff(StructBuffManager structBuffManager, buff2 buff2)
        {
            structBuffManager.AddBuff(new Enity(), buff2);
        }

        [Test]
        public void 结构值字段buff()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();
            structBuffManager.AddBuff(new Enity(), new buff3(_getCurrentMilliSeconds()));
        }

        [Test]
        public void 结构含引用字段buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff4(_getCurrentMilliSeconds())); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含引用属性buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff5(_getCurrentMilliSeconds())); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含私有引用字段buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff6(_getCurrentMilliSeconds())); });
            Debug.Log(ex.Message);
        }
        
        [Test]
        public void 结构含私有引用属性buff不允许()
        {
            // Use the Assert class to test conditions.
            StructBuffManager structBuffManager = new StructBuffManager();

            var ex = Assert.Catch<TypeErrorException>(() => { structBuffManager.AddBuff(new Enity(), new buff7(_getCurrentMilliSeconds())); });
            
            Debug.Log(ex.Message);
        }
    }
}