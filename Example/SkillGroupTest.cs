//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-01:43
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using UnityEngine;

namespace  CabinIcarus.IcSkillSystem.Expansions
{
    public class TestEntity : IEntity
    {
    }
    public class SkillGroupTest : MonoBehaviour
    {
        public GameRoot Root;
        
        private Root behaviorTree;

        public IcSkillGroup Group;

        public string ShardBlackboardName = "Test";
    
        private void Start()
        {
            //创建共享黑板,记住这里需要和 Group 中的 共享黑板key一样
            var blackboard = UnityContext.GetSharedBlackboard(ShardBlackboardName);
            
            //设置黑板值,目前一把梭写得方式,后续这些将会变为节点
            blackboard.Set(BlackBoardConstKeyTables.BuffManager,Root.BuffManager);
            blackboard.Set(BlackBoardConstKeyTables.SkillManager,Root.SkillManager);
            
            //Group 开始执行,他会返回一个Root节点
            behaviorTree = Group.Start();
            
#if UNITY_EDITOR
            Debugger debugger = (Debugger)this.gameObject.AddComponent(typeof(Debugger));
            debugger.BehaviorTree = behaviorTree;
#endif
            //行为树开始执行
            behaviorTree?.Start();
        }
    }
}