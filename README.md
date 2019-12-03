# SkillSystem

[0.6 last Video](https://www.bilibili.com/video/av76312353)

Example Unity Version:2019.2+

Behave Tree Create Editor

Add a new buffManager, the buff needs to be a structure

#### ECS Buff System

##### Create Buff

Implement `IBuffDataComponent`

![](ReadmeImages/IDamageBufff.png)

![](ReadmeImages/Buff.png)

##### Buff System

Create System Implement `IBuffCreateSystem`

![Create](ReadmeImages/ECSBuffCreateSystem.png)

Update System Implement `IBuffUpdateSystem`

![Update](ReadmeImages/ECSBuffUpdateSystem.png)

Destroy System Implement `IBuffDestroySystem`

![Destroy](ReadmeImages/ECSBuffDestroySystem.png)


##### Buff System

Add Buff System

```c#

BuffManager_Struct BuffManager = new BuffManager_Struct();

BuffManager.AddBuffSystem<TBuff>(new BuffSystem())
```

need Implement custom BuffManager, Implement `IBuffManager`

![Update Buff System](ReadmeImages/UpdateBuffSystem.png)

![Add Buff System](ReadmeImages/ECSBuffSystem.png)

Add Buff

![Add Buff](ReadmeImages/AddBuff.png)

Remove Buff

![Remove Buff](ReadmeImages/RemoveBuff.png)

###Skill Group

Cast Node And For Execute Action Node

![Cast](ReadmeImages/Cast.png)

Child Group And Multi Group Editor Support

![ChildAndMultEditWindow](ReadmeImages/ChildAndMultEditWindow.png)

Dynamic Type Select Support

![Remove](ReadmeImages/DynamicTypeSelection.png)

Node Search Support

![Remove](ReadmeImages/NodeSearch.png)

Node Order

![Remove](ReadmeImages/NodeOrder.png)

Node Order Show

![Remove](ReadmeImages/NodeOrderShow.png)

Skill Group Blackboard Variable Support

![Remove](ReadmeImages/GroupBlackboardVariable.png)



