using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionShakeObject : IAction
{ 
public GameObject shaker;

private float shakeX;

private float shakeY;

private float shakeZ;

public NumberProperty shake_x = new NumberProperty(0.01f);

public NumberProperty shake_y = new NumberProperty(0.01f);

public NumberProperty shake_z = new NumberProperty(0.01f);

public NumberProperty InitialtimerValue = new NumberProperty(0f);

public NumberProperty IntervaltimerValue = new NumberProperty(0f);

public NumberProperty LoopCount = new NumberProperty(0f);

public bool InfiniteLoops;

private float loopsCounted = 1f;

private bool Up;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
base.CancelInvoke("Shaking");
this.shakeX = this.shake_x.GetValue(base.gameObject);
this.shakeY = this.shake_y.GetValue(base.gameObject);
this.shakeZ = this.shake_z.GetValue(base.gameObject);
base.InvokeRepeating("Shaking", this.InitialtimerValue.GetValue(target), this.IntervaltimerValue.GetValue(target));
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void Shaking()
{ 
if (this.Up)
{ 
this.shaker.transform.Translate(this.shakeX, this.shakeY, this.shakeZ);
this.Up = false;
}
else
{ 
this.shaker.transform.Translate(-this.shakeX, -this.shakeY, -this.shakeZ);
this.Up = true;
}
this.loopsCounted += 1f;
if (this.LoopCount.GetValue() < this.loopsCounted && !this.InfiniteLoops)
{ 
base.CancelInvoke("Shaking");
}
}
}
}
