using GameCreator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionRandomActionFromList : IAction
{ 
[Serializable]
public class ActionObject
{ 
public Actions actionToExecute;

[Range(1f, 100f)]
public int Probability;

[HideInInspector]
public int actionweight;
}

[SerializeField]
public List<ActionRandomActionFromList.ActionObject> ListofActions = new List<ActionRandomActionFromList.ActionObject>();

private Actions actionsToExecute;

public bool waitToFinish;

public bool executeAllActions;

private bool actionsComplete;

private bool forceStop;

[IteratorStateMachine(typeof(ActionRandomActionFromList.<Execute>d__7))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0:
{ 
int index2 = this.RandomProbability();
this.actionsToExecute = this.ListofActions[index2].actionToExecute;
if (!(this.actionsToExecute != null))
{ 
goto IL_B4;
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
goto IL_B4;
}
case 1: 
goto IL_B4;
case 2: 
goto IL_C9;
 }
break;
IL_B4:
yield return 0;
}
yield break;
IL_C9:
yield break;
num
index2
waitUntil
}

public int RandomProbability()
{ 
int num = 0;
if (this.ListofActions.Capacity > 0)
{ 
for (int i = 0; i < this.ListofActions.Capacity; i++)
{ 
num += this.ListofActions[i].Probability;
}
int num2 = 0;
int num3 = UnityEngine.Random.Range(0, num);
int j;
for (j = 0; j < this.ListofActions.Capacity; j++)
{ 
num2 += this.ListofActions[j].Probability;
if (num2 > num3)
{ 
break;
}
}
return j;
}
return 0;
num
i
num2
num3
j
}

private void OnCompleteActions()
{ 
this.actionsComplete = true;
}
}
}
