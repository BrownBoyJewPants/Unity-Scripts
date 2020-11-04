using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshTimer : IAction
{ 
public enum RESULT
{ 
Action,
Condition
}

public GameObject textObject;

private TextMeshPro textdata;

public Action3DTextMeshTimer.RESULT timerResult;

public bool countdown;

public bool countup;

public NumberProperty InitialtimerValue = new NumberProperty(0f);

public NumberProperty TotaltimerValue = new NumberProperty(10f);

public Actions actionToCall;

public Conditions conditionToCall;

private float timervalue;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(Action3DTextMeshTimer.<Execute>d__12))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0:
{ 
this.timervalue = this.TotaltimerValue.GetValue(target);
if (!this.countdown)
{ 
this.timervalue = 1f;
}
base.CancelInvoke("Timer");
base.InvokeRepeating("Timer", this.InitialtimerValue.GetValue(target), 1f);
float seconds = this.TotaltimerValue.GetValue(target) + this.InitialtimerValue.GetValue(target);
yield return new WaitForSeconds(seconds);
continue;
}
case 1:
{ 
base.CancelInvoke("Timer");
if (this.countdown)
{ 
this.textdata.text = "0";
}
Action3DTextMeshTimer.RESULT rESULT = this.timerResult;
if (rESULT != Action3DTextMeshTimer.RESULT.Action)
{ 
if (rESULT == Action3DTextMeshTimer.RESULT.Condition)
{ 
this.textdata.text = this.timervalue.ToString();
this.conditionToCall.Interact(base.gameObject, Array.Empty<object>());
}
}
else
{ 
this.actionToCall.Execute(base.gameObject, null);
}
yield return 0;
continue;
}
case 2: 
goto IL_147;
 }
break;
}
yield break;
IL_147:
yield break;
num
seconds
rESULT
}

private void Timer()
{ 
this.textdata = this.textObject.GetComponent<TextMeshPro>();
if (this.countdown)
{ 
this.textdata.text = this.timervalue.ToString();
this.timervalue -= 1f;
return;
}
this.textdata.text = this.timervalue.ToString();
this.timervalue += 1f;
}
}
}
