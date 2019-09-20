//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-01:43
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Expansions.Skills;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Manager;
using UnityEngine;

namespace  CabinIcarus.IcSkillSystem.Expansions
{
    public class TestEntity : IEntity
    {
    }
    public class SkillGroupTest : MonoBehaviour
    {
        private Root behaviorTree;

        public IcSkillGroup Group;

        public string ShardBlackboardName = "Test";
        private BuffManager _buffManager;
        private SkillManager _skillManager;

        private void Start()
        {
            //创建共享黑板,记住这里需要和 Group 中的 共享黑板key一样
            var blackboard = UnityContext.GetSharedBlackboard(ShardBlackboardName);
            
            _buffManager = new BuffManager();
            _skillManager = new SkillManager();
            
            _buffManager
                //固定减伤buff
                .AddBuffSystem(new DamageReduceFixedSystem(_buffManager))
                //百分比减伤buff
                .AddBuffSystem(new DamageReducePercentageSystem(_buffManager))
                //持续伤害buff
                .AddBuffSystem(new ContinuousDamageSystem<DamageBuff>(_buffManager))
                //伤害buff
                .AddBuffSystem(new DamageSystem(_buffManager));
            
            
            _skillManager
                // Hello World Skill 同时随机一个buff
                .AddSkillSystem(new HelloWorldSkillSystem(_buffManager));
            
          
            //创建entity
            var testEntity = new TestEntity();

#if UNITY_EDITOR
            //创建buff 连接来辅助调试
            GameObject go = new GameObject("测试实体");
            var buffLink = go.AddComponent<BuffEntityLinkComponent>();
            buffLink.Init(_buffManager,testEntity);
#endif
            //设置黑板值,目前一把梭写得方式,后续这些将会变为节点
            blackboard.Set(BlackBoardConstKeyTables.BuffManager,_buffManager);
            blackboard.Set(BlackBoardConstKeyTables.SkillManager,_skillManager);
            blackboard.Set(BlackBoardConstKeyTables.UseSkillEntity,testEntity);
            
            //Group 开始执行,他会返回一个Root节点
            behaviorTree = Group.Start();
            
#if UNITY_EDITOR
            Debugger debugger = (Debugger)this.gameObject.AddComponent(typeof(Debugger));
            debugger.BehaviorTree = behaviorTree;
#endif
            //行为树开始执行
            behaviorTree?.Start();
        }

        private void Update()
        {
            //buff系统更新
            _buffManager.Update();
        }
    }
}