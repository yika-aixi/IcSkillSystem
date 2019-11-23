using System;
using CabinIcarus.IcSkillSystem.Runtime.Nodes;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Composite;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks;
using NPBehave;
using XNodeEditor;
using Action = NPBehave.Action;
using Random = NPBehave.Random;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Nodes
{
    [CustomNodeEditorAttribute(typeof(ParallelNode))]
    public class ParallelNodeEditor : ANPBehaveNodeEditor<ParallelNode, Parallel>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(RandomSelectorNode))]
    public class RandomSelectorNodeEditor : ANPBehaveNodeEditor<RandomSelectorNode, RandomSelector>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(RandomSequenceNode))]
    public class RandomSequenceNodeEditor : ANPBehaveNodeEditor<RandomSequenceNode, RandomSequence>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(SelectorNode))]
    public class SelectorNodeEditor : ANPBehaveNodeEditor<SelectorNode, Selector>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(SequenceNode))]
    public class SequenceNodeEditor : ANPBehaveNodeEditor<SequenceNode, Sequence>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(BlackboardConditionNode))]
    public class BlackboardConditionNodeEditor : ANPBehaveNodeEditor<BlackboardConditionNode, BlackboardCondition>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(BlackboardQueryNode))]
    public class BlackboardQueryNodeEditor : ANPBehaveNodeEditor<BlackboardQueryNode, BlackboardQuery>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(ConditionNode))]
    public class ConditionNodeEditor : ANPBehaveNodeEditor<ConditionNode, Condition>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(CooldownNode))]
    public class CooldownNodeEditor : ANPBehaveNodeEditor<CooldownNode, Cooldown>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(FailerNode))]
    public class FailerNodeEditor : ANPBehaveNodeEditor<FailerNode, Failer>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(InverterNode))]
    public class InverterNodeEditor : ANPBehaveNodeEditor<InverterNode, Inverter>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(ObserverNode))]
    public class ObserverNodeEditor : ANPBehaveNodeEditor<ObserverNode, Observer>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(RandomNode))]
    public class RandomNodeEditor : ANPBehaveNodeEditor<RandomNode, Random>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(ServiceNode))]
    public class ServiceNodeEditor : ANPBehaveNodeEditor<ServiceNode, Service>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(SucceederNode))]
    public class SucceederNodeEditor : ANPBehaveNodeEditor<SucceederNode, Succeeder>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(TimeMaxNode))]
    public class TimeMaxNodeEditor : ANPBehaveNodeEditor<TimeMaxNode, TimeMax>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(TimeMinNode))]
    public class TimeMinNodeEditor : ANPBehaveNodeEditor<TimeMinNode, TimeMin>
    {
    }

    [CustomNodeEditorAttribute(typeof(ANPBehaveNode<Wait>))]
    public class WaitNodeEditor : ANPBehaveNodeEditor<ANPBehaveNode<Wait>, Wait>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(RepeaterNode))]
    public class RepeaterNodeEditor : ANPBehaveNodeEditor<RepeaterNode, Repeater>
    {
    }
    
    [CustomNodeEditorAttribute(typeof(WaitForConditionNode))]
    public class WaitForConditionNodeEditor : ANPBehaveNodeEditor<WaitForConditionNode, WaitForCondition>
    {
    }
}