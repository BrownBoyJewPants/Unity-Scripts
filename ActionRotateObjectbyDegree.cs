using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionRotateObjectbyDegree : IAction
{ 
public GameObject objecttoRotate;

private float originalValy;

private float originalValx;

private float originalValz;

private Vector3 objOrigPos;

private Vector3 objNewPos;

public Vector3 rotation = new Vector3(90f, 0f, 0f);

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

[IteratorStateMachine(typeof(ActionRotateObjectbyDegree.<Execute>d__20))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
Quaternion quaternion;
Quaternion quaternion2;
float value;
float time;
switch (num)
{ 
case 0: 
this.objectTransform = this.objecttoRotate.GetComponent<Transform>();
quaternion = this.objectTransform.rotation;
quaternion2 = Quaternion.identity;
quaternion2 = this.objectTransform.rotation * Quaternion.Euler(this.rotation);
if (this.xvalue)
{ 
this.rotation.x = this.transform_x.GetValue(target);
}
else
{ 
this.rotation.x = 0f;
}
if (this.yvalue)
{ 
this.rotation.y = this.transform_y.GetValue(target);
}
else
{ 
this.rotation.y = 0f;
}
if (this.zvalue)
{ 
this.rotation.z = this.transform_z.GetValue(target);
}
else
{ 
this.rotation.z = 0f;
}
quaternion2 = this.objectTransform.rotation * Quaternion.Euler(this.rotation);
value = this.moveSpeed.GetValue(target);
time = Time.time;
goto IL_1D3;
case 1: 
goto IL_1D3;
case 2: 
goto IL_229;
case 3: 
goto IL_2A7;
case 4: 
goto IL_2D3;
 }
break;
IL_1D3:
if (Time.time - time < value && !(this.objectTransform == null))
{ 
float t = (Time.time - time) / value;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
this.objectTransform.rotation = Quaternion.LerpUnclamped(quaternion, quaternion2, ease);
yield return null;
continue;
}
if (!this.returnTo)
{ 
goto IL_2BE;
}
if (this.returnToWait)
{ 
yield return new WaitForSeconds(this.waituntilreturn.GetValue(target));
continue;
}
goto IL_229;
IL_2A7:
if (Time.time - time < value && !(this.objectTransform == null))
{ 
float t2 = (Time.time - time) / value;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
this.objectTransform.rotation = Quaternion.LerpUnclamped(quaternion2, quaternion, ease2);
yield return null;
continue;
}
goto IL_2BE;
IL_229:
time = Time.time;
goto IL_2A7;
IL_2BE:
yield return 0;
}
yield break;
IL_2D3:
yield break;
num
quaternion
quaternion2
value
time
t
ease
t2
ease2
}
}
}
