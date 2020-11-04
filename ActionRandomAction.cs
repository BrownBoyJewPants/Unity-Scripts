using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionRandomAction : IAction
{ 
public Actions actions1;

public Actions actions2;

public Actions actions3;

public Actions actions4;

private Actions actionsToExecute;

public bool fromVar;

[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.Number
})]
public VariableProperty variableRandom = new VariableProperty(Variable.VarType.GlobalVariable);

public bool waitToFinish;

private bool actionsComplete;

private bool forceStop;

private float randomVar;

[IteratorStateMachine(typeof(ActionRandomAction.<Execute>d__11))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0:
{ 
if (this.fromVar)
{ 
this.randomVar = (float)this.variableRandom.Get(target);
}
else
{ 
this.randomVar = (float)UnityEngine.Random.Range(1, 5);
}
float obj = this.randomVar;
if (!1f.Equals(obj))
{ 
if (!2f.Equals(obj))
{ 
if (!3f.Equals(obj))
{ 
if (4f.Equals(obj))
{ 
this.actionsToExecute = this.actions4;
}
}
else
{ 
this.actionsToExecute = this.actions3;
}
}
else
{ 
this.actionsToExecute = this.actions2;
}
}
else
{ 
this.actionsToExecute = this.actions1;
}
if (!(this.actionsToExecute != null))
{ 
goto IL_14B;
}
this.actionsComplete = false;
this.actionsToExecute.actionsList.Execute(target, new Action(this.OnCompleteActions), Array.Empty<object>());
if (this.waitToFinish)
{ 
WaitUntil waitUntil = new WaitUntil(delegate
{ 
if (this.actionsToExecute == null)
{ 
return true;
}
if (this.forceStop)
{ 
this.actionsToExecute.actionsList.Stop();
return true;
}
return this.actionsComplete;
});
yield return waitUntil;
continue;
}
goto IL_14B;
}
case 1: 
goto IL_14B;
case 2: 
goto IL_160;
 }
break;
IL_14B:
yield return 0;
}
yield break;
IL_160:
yield break;
num
obj
waitUntil
}

private void OnCompleteActions()
{ 
this.actionsComplete = true;
}
}
}
