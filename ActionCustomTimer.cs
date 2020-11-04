using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionCustomTimer : IAction
{ 
public enum RESULT
{ 
Action,
Condition
}

public ActionCustomTimer.RESULT timerResult;

public NumberProperty InitialtimerValue = new NumberProperty(0f);

public NumberProperty IntervaltimerValue = new NumberProperty(0f);

public NumberProperty LoopCount = new NumberProperty(0f);

public bool InfiniteLoops;

public Actions actionToCall;

public Conditions conditionToCall;

private float loopsCounted = 1f;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
base.CancelInvoke("Finished");
base.InvokeRepeating("Finished", this.InitialtimerValue.GetValue(target), this.IntervaltimerValue.GetValue(target));
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void Finished()
{ 
ActionCustomTimer.RESULT rESULT = this.timerResult;
if (rESULT != ActionCustomTimer.RESULT.Action)
{ 
if (rESULT == ActionCustomTimer.RESULT.Condition)
{ 
this.conditionToCall.Interact(base.gameObject, Array.Empty<object>());
}
}
else
{ 
this.actionToCall.Execute(base.gameObject, null);
}
this.loopsCounted += 1f;
if (this.LoopCount.GetValue(base.gameObject) < this.loopsCounted && !this.InfiniteLoops)
{ 
base.CancelInvoke("Finished");
}
rESULT
}
}
}
