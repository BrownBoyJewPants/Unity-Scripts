using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionRotateCanvasOut : IAction
{ 
public enum ALIGN
{ 
Top,
Bottom,
Left,
Right
}

public GameObject canvasPanel;

public RectTransform animpanel;

public ActionRotateCanvasOut.ALIGN alignment;

public NumberProperty AnimateDuration = new NumberProperty(1f);

public Easing.EaseType easing = Easing.EaseType.QuadInOut;

public Vector3 animStartPosition;

public Vector3 AnimInPosition;

public Vector3 AnimOutPositionTop;

public Vector3 AnimOutPositionBottom;

public Vector3 AnimOutPositionLeft;

public Vector3 AnimOutPositionRight;

private Vector3 rotation;

private Quaternion rotation2;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionRotateCanvasOut.<Execute>d__15))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
float num2;
float unscaledTime;
switch (num)
{ 
case 0:
{ 
this.animpanel = this.canvasPanel.GetComponent<RectTransform>();
Transform arg_51_0 = this.animpanel.transform;
this.AnimInPosition = new Vector3(0f, 0f, 0f);
this.animStartPosition = this.animpanel.localPosition;
this.AnimOutPositionTop = new Vector3(0f, (float)Screen.height, 0f);
this.AnimOutPositionBottom = new Vector3(0f, (float)(-(float)Screen.height), 0f);
this.AnimOutPositionLeft = new Vector3((float)(-(float)Screen.width), 0f, 0f);
this.AnimOutPositionRight = new Vector3((float)Screen.width, 0f, 0f);
num2 = this.AnimateDuration.GetValue(target);
if (num2 < 0.2f)
{ 
num2 = 0.2f;
}
unscaledTime = Time.unscaledTime;
Quaternion identity = Quaternion.identity;
switch (this.alignment)
{ 
case ActionRotateCanvasOut.ALIGN.Top: 
this.animpanel.pivot = new Vector2(0f, 1f);
this.rotation = new Vector3(90f, 0f, 0f);
this.rotation2 = Quaternion.Euler(this.rotation);
goto IL_20B;
case ActionRotateCanvasOut.ALIGN.Bottom: 
this.animpanel.pivot = new Vector2(1f, 0f);
this.rotation = new Vector3(-90f, 0f, 0f);
this.rotation2 = Quaternion.Euler(this.rotation);
goto IL_2E2;
case ActionRotateCanvasOut.ALIGN.Left: 
this.animpanel.pivot = new Vector2(0f, 0.5f);
this.rotation = new Vector3(0f, 90f, 0f);
this.rotation2 = Quaternion.Euler(this.rotation);
goto IL_3B9;
case ActionRotateCanvasOut.ALIGN.Right: 
this.animpanel.pivot = new Vector2(1f, 1f);
this.rotation = new Vector3(0f, -90f, 0f);
this.rotation2 = Quaternion.Euler(this.rotation);
goto IL_48D;
default: 
goto IL_4A4;
 }
break;
}
case 1: 
goto IL_20B;
case 2: 
goto IL_2E2;
case 3: 
goto IL_3B9;
case 4: 
goto IL_48D;
case 5: 
goto IL_4B9;
 }
break;
IL_20B:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_4A4;
}
if (!(this.animpanel == null))
{ 
float t = (Time.unscaledTime - unscaledTime) / num2;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
Quaternion identity;
this.animpanel.localRotation = Quaternion.Lerp(identity, this.rotation2, ease);
yield return null;
continue;
}
goto IL_4A4;
IL_2E2:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_4A4;
}
if (!(this.animpanel == null))
{ 
float t2 = (Time.unscaledTime - unscaledTime) / num2;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
Quaternion identity;
this.animpanel.localRotation = Quaternion.Lerp(identity, this.rotation2, ease2);
yield return null;
continue;
}
goto IL_4A4;
IL_3B9:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_4A4;
}
if (!(this.animpanel == null))
{ 
float t3 = (Time.unscaledTime - unscaledTime) / num2;
float ease3 = Easing.GetEase(this.easing, 0f, 1f, t3);
Quaternion identity;
this.animpanel.localRotation = Quaternion.Lerp(identity, this.rotation2, ease3);
yield return null;
continue;
}
goto IL_4A4;
IL_48D:
if (Time.unscaledTime - unscaledTime < num2 && !(this.animpanel == null))
{ 
float t4 = (Time.unscaledTime - unscaledTime) / num2;
float ease4 = Easing.GetEase(this.easing, 0f, 1f, t4);
Quaternion identity;
this.animpanel.localRotation = Quaternion.Lerp(identity, this.rotation2, ease4);
yield return null;
continue;
}
IL_4A4:
yield return 0;
}
yield break;
IL_4B9:
yield break;
num
arg_51_0
num2
unscaledTime
identity
t
ease
t2
ease2
t3
ease3
t4
ease4
}
}
}
