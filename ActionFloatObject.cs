using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionFloatObject : IAction
{ 
public GameObject floater;

private float tempValy;

private float tempValx;

private float tempValz;

private Vector3 objPos;

public NumberProperty amplitude_y = new NumberProperty(0.01f);

public NumberProperty speed_y = new NumberProperty(1f);

public NumberProperty amplitude_x = new NumberProperty(0.01f);

public NumberProperty speed_x = new NumberProperty(5f);

public NumberProperty amplitude_z = new NumberProperty(0.01f);

public NumberProperty speed_z = new NumberProperty(5f);

public NumberProperty InitialtimerValue = new NumberProperty(0f);

public NumberProperty IntervaltimerValue = new NumberProperty(0f);

public NumberProperty LoopCount = new NumberProperty(0f);

public bool InfiniteLoops;

private float loopsCounted = 1f;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
base.CancelInvoke("Floating");
base.InvokeRepeating("Floating", this.InitialtimerValue.GetValue(target), this.IntervaltimerValue.GetValue(target));
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void Floating()
{ 
this.tempValy = this.floater.transform.position.y;
this.tempValx = this.floater.transform.position.x;
this.tempValz = this.floater.transform.position.z;
this.objPos.y = this.tempValy + this.amplitude_y.GetValue(base.gameObject) * Mathf.Sin(this.speed_y.GetValue(base.gameObject) * Time.time);
this.objPos.x = this.tempValx + this.amplitude_x.GetValue(base.gameObject) * Mathf.Sin(this.speed_x.GetValue(base.gameObject) * Time.time);
this.objPos.z = this.tempValz + this.amplitude_z.GetValue(base.gameObject) * Mathf.Sin(this.speed_z.GetValue(base.gameObject) * Time.time);
this.floater.transform.position = this.objPos;
this.loopsCounted += 1f;
if (this.LoopCount.GetValue() < this.loopsCounted && !this.InfiniteLoops)
{ 
base.CancelInvoke("Floating");
}
}
}
}
