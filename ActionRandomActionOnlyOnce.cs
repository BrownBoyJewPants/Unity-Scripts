using GameCreator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionRandomActionOnlyOnce : IAction
{ 
public enum RESULT
{ 
Action,
Condition
}

[Serializable]
public class ActionObject
{ 
public Actions actionToExecute;
}

public ActionRandomActionOnlyOnce.RESULT result;

public Actions actionToCall;

public Conditions conditionToCall;

[SerializeField]
public List<ActionRandomActionOnlyOnce.ActionObject> ListofActions = new List<ActionRandomActionOnlyOnce.ActionObject>();

private Actions actionsToExecute;

public bool waitToFinish;

public bool executeOnFinish;

private bool actionsComplete;

private bool forceStop;

private bool repeat;

private int rand;

private int randTotal;

[IteratorStateMachine(typeof(ActionRandomActionOnlyOnce.<Execute>d__14))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0: 
if (!this.repeat)
{ 
this.rand = UnityEngine.Random.Range(0, this.ListofActions.Capacity);
this.randTotal = this.ListofActions.Capacity;
}
else if (this.repeat)
{ 
this.rand = UnityEngine.Random.Range(0, this.randTotal);
}
if (this.randTotal > 0)
{ 
this.actionsToExecute = this.ListofActions[this.rand].actionToExecute;
if (!(this.actionsToExecute != null))
{ 
goto IL_10A;
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
goto IL_10A;
}
else
{ 
ActionRandomActionOnlyOnce.RESULT rESULT = this.result;
if (rESULT == ActionRandomActionOnlyOnce.RESULT.Action)
{ 
this.actionToCall.Execute(base.gameObject, null);
goto IL_16C;
}
if (rESULT != ActionRandomActionOnlyOnce.RESULT.Condition)
{ 
goto IL_16C;
}
this.conditionToCall.Interact(base.gameObject, Array.Empty<object>());
goto IL_16C;
}
break;
case 1: 
goto IL_10A;
case 2: 
goto IL_181;
 }
break;
IL_16C:
yield return 0;
continue;
IL_10A:
this.ListofActions.RemoveAt(this.rand);
this.randTotal--;
this.repeat = true;
goto IL_16C;
}
yield break;
IL_181:
yield break;
num
waitUntil
rESULT
}

private void OnCompleteActions()
{ 
this.actionsComplete = true;
}
}
}
