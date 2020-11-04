using GameCreator.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionShakeElement : IAction
{ 
public GameObject shaker;

public float Duration = 3f;

public float Amount = 5f;

private Vector3 originalPos;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.originalPos = base.transform.parent.localPosition;
base.StopAllCoroutines();
base.StartCoroutine(this.cShake(this.Duration, this.Amount));
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

[IteratorStateMachine(typeof(ActionShakeElement.<cShake>d__6))]
public IEnumerator cShake(float duration, float amount)
{ 
while (true)
{ 
int num;
float num2;
if (num != 0)
{ 
if (num != 1)
{ 
break;
}
}
else
{ 
num2 = Time.time + duration;
this.shaker.transform.localPosition = this.originalPos;
}
if (Time.time >= num2)
{ 
goto Block_3;
}
this.shaker.transform.localPosition = this.originalPos + UnityEngine.Random.insideUnitSphere * amount;
duration -= Time.deltaTime;
yield return null;
}
yield break;
Block_3:
this.shaker.transform.localPosition = this.originalPos;
yield break;
num
num2
}
}
}
