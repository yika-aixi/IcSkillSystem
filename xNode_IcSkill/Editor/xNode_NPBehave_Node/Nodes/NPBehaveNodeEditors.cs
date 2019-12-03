using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Composite;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator;
using NPBehave;
using Random = NPBehave.Random;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(ParallelNode))]
    public class ParallelNodeEditor : ANPBehaveNodeEditor<ParallelNode, Parallel>
    {
    }
    
    [CustomNodeEditor(typeof(RandomSelectorNode))]
    public class RandomSelectorNodeEditor : ANPBehaveNodeEditor<RandomSelectorNode, RandomSelector>
    {
    }
    
    [CustomNodeEditor(typeof(RandomSequenceNode))]
    public class RandomSequenceNodeEditor : ANPBehaveNodeEditor<RandomSequenceNode, RandomSequence>
    {
    }
    
    [CustomNodeEditor(typeof(SelectorNode))]
    public class SelectorNodeEditor : ANPBehaveNodeEditor<SelectorNode, Selector>
    {
    }
    
    [CustomNodeEditor(typeof(SequenceNode))]
    public class SequenceNodeEditor : ANPBehaveNodeEditor<SequenceNode, Sequence>
    {
    }
    
    [CustomNodeEditor(typeof(BlackboardConditionNode))]
    public class BlackboardConditionNodeEditor : ANPBehaveNodeEditor<BlackboardConditionNode, BlackboardCondition>
    {
    }
    
    [CustomNodeEditor(typeof(ABlackboardQueryNode))]
    public class BlackboardQueryNodeEditor : ANPBehaveNodeEditor<ABlackboardQueryNode, BlackboardQuery>
    {
    }
    
    [CustomNodeEditor(typeof(AConditionNode))]
    public class ConditionNodeEditor : ANPBehaveNodeEditor<AConditionNode, Condition>
    {
    }
    
    [CustomNodeEditor(typeof(CooldownNode))]
    public class CooldownNodeEditor : ANPBehaveNodeEditor<CooldownNode, Cooldown>
    {
    }
    
    [CustomNodeEditor(typeof(FailerNode))]
    public class FailerNodeEditor : ANPBehaveNodeEditor<FailerNode, Failer>
    {
    }
    
    [CustomNodeEditor(typeof(InverterNode))]
    public class InverterNodeEditor : ANPBehaveNodeEditor<InverterNode, Inverter>
    {
    }
    
    [CustomNodeEditor(typeof(AObserverNode))]
    public class ObserverNodeEditor : ANPBehaveNodeEditor<AObserverNode, Observer>
    {
    }
    
    [CustomNodeEditor(typeof(RandomNode))]
    public class RandomNodeEditor : ANPBehaveNodeEditor<RandomNode, Random>
    {
    }
    
    [CustomNodeEditor(typeof(AServiceNode))]
    public class ServiceNodeEditor : ANPBehaveNodeEditor<AServiceNode, Service>
    {
    }
    
    [CustomNodeEditor(typeof(SucceederNode))]
    public class SucceederNodeEditor : ANPBehaveNodeEditor<SucceederNode, Succeeder>
    {
    }
    
    [CustomNodeEditor(typeof(TimeMaxNode))]
    public class TimeMaxNodeEditor : ANPBehaveNodeEditor<TimeMaxNode, TimeMax>
    {
    }
    
    [CustomNodeEditor(typeof(TimeMinNode))]
    public class TimeMinNodeEditor : ANPBehaveNodeEditor<TimeMinNode, TimeMin>
    {
    }

    [CustomNodeEditor(typeof(ANPBehaveNode<Wait>))]
    public class WaitNodeEditor : ANPBehaveNodeEditor<ANPBehaveNode<Wait>, Wait>
    {
    }
    
    [CustomNodeEditor(typeof(RepeaterNode))]
    public class RepeaterNodeEditor : ANPBehaveNodeEditor<RepeaterNode, Repeater>
    {
    }
    
    [CustomNodeEditor(typeof(AWaitForConditionNode))]
    public class WaitForConditionNodeEditor : ANPBehaveNodeEditor<AWaitForConditionNode, WaitForCondition>
    {
    }
}