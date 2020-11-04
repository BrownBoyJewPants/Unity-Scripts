using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionMoveObjectbyDistance : IAction
{ 
public GameObject objecttoMove;

private float originalValy;

private float originalValx;

private float originalValz;

private Vector3 objOrigPos;

private Vector3 objNewPos;

public NumberProperty transform_y = new NumberProperty(0f);

public NumberProperty transform_x = new NumberProperty(0f);

public NumberProperty transform_z = new NumberProperty(0f);

public NumberProperty moveSpeed = new NumberProperty(1f);

public bool xvalue;

public bool yvalue;

public bool zvalue;

public bool returnTo;

public bool returnToWait;

public NumberProperty waituntilreturn = new NumberProperty(1f);

public Easing.EaseType easing = Easing.EaseType.QuadInOut;

private Transform objectTransform;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionMoveObjectbyDistance.<Execute>d__19))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
float value;
float time;
switch (num)
{ 
case 0: 
this.objectTransform = this.objecttoMove.GetComponent<Transform>();
this.objOrigPos = this.objectTransform.position;
this.originalValx = this.objectTransform.position.x;
this.originalValy = this.objectTransform.position.y;
this.originalValz = this.objectTransform.position.z;
if (this.xvalue)
{ 
this.objNewPos.x = this.originalValx + this.transform_x.GetValue(target);
}
else
{ 
this.objNewPos.x = this.originalValx;
}
if (this.yvalue)
{ 
this.objNewPos.y = this.originalValy + this.transform_y.GetValue(target);
}
else
{ 
this.objNewPos.y = this.originalValy;
}
if (this.zvalue)
{ 
this.objNewPos.z = this.originalValz + this.transform_z.GetValue(target);
}
else
{ 
this.objNewPos.z = this.originalValz;
}
value = this.moveSpeed.GetValue(target);
time = Time.time;
goto IL_1E0;
case 1: 
goto IL_1E0;
case 2: 
goto IL_236;
case 3: 
goto IL_2B4;
case 4: 
goto IL_2E0;
 }
break;
IL_1E0:
if (Time.time - time < value && !(this.objectTransform == null))
{ 
float t = (Time.time - time) / value;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
this.objectTransform.position = Vector3.Lerp(this.objOrigPos, this.objNewPos, ease);
yield return null;
continue;
}
if (!this.returnTo)
{ 
goto IL_2CB;
}
if (this.returnToWait)
{ 
yield return new WaitForSeconds(this.waituntilreturn.GetValue(target));
continue;
}
goto IL_236;
IL_2B4:
if (Time.time - time < value && !(this.objectTransform == null))
{ 
float t2 = (Time.time - time) / value;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
this.objectTransform.position = Vector3.Lerp(this.objNewPos, this.objOrigPos, ease2);
yield return null;
continue;
}
goto IL_2CB;
IL_236:
time = Time.time;
goto IL_2B4;
IL_2CB:
yield return 0;
}
yield break;
IL_2E0:
yield break;
num
value
time
t
ease
t2
ease2
}
}
}
