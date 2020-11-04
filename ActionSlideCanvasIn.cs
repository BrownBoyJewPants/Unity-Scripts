using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionSlideCanvasIn : IAction
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

public ActionSlideCanvasIn.ALIGN alignment;

public NumberProperty AnimateDuration = new NumberProperty(1f);

public Easing.EaseType easing = Easing.EaseType.QuadInOut;

public Vector3 animStartPosition;

public Vector3 AnimInPosition;

public Vector3 AnimOutPositionTop;

public Vector3 AnimOutPositionBottom;

public Vector3 AnimOutPositionLeft;

public Vector3 AnimOutPositionRight;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionSlideCanvasIn.<Execute>d__13))]
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
this.animpanel = this.canvasPanel.GetComponent<RectTransform>();
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
switch (this.alignment)
{ 
case ActionSlideCanvasIn.ALIGN.Top: 
goto IL_1AD;
case ActionSlideCanvasIn.ALIGN.Bottom: 
goto IL_23D;
case ActionSlideCanvasIn.ALIGN.Left: 
goto IL_2CD;
case ActionSlideCanvasIn.ALIGN.Right: 
goto IL_35A;
default: 
goto IL_371;
 }
break;
case 1: 
goto IL_1AD;
case 2: 
goto IL_23D;
case 3: 
goto IL_2CD;
case 4: 
goto IL_35A;
case 5: 
goto IL_386;
 }
break;
IL_1AD:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_371;
}
if (!(this.animpanel == null))
{ 
float t = (Time.unscaledTime - unscaledTime) / num2;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
this.animpanel.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimInPosition, ease);
yield return null;
continue;
}
goto IL_371;
IL_23D:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_371;
}
if (!(this.animpanel == null))
{ 
float t2 = (Time.unscaledTime - unscaledTime) / num2;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
this.animpanel.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimInPosition, ease2);
yield return null;
continue;
}
goto IL_371;
IL_2CD:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_371;
}
if (!(this.animpanel == null))
{ 
float t3 = (Time.unscaledTime - unscaledTime) / num2;
float ease3 = Easing.GetEase(this.easing, 0f, 1f, t3);
this.animpanel.localPosition = Vector3.Lerp(this.AnimOutPositionLeft, this.AnimInPosition, ease3);
yield return null;
continue;
}
goto IL_371;
IL_35A:
if (Time.unscaledTime - unscaledTime < num2 && !(this.animpanel == null))
{ 
float t4 = (Time.unscaledTime - unscaledTime) / num2;
float ease4 = Easing.GetEase(this.easing, 0f, 1f, t4);
this.animpanel.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimInPosition, ease4);
yield return null;
continue;
}
IL_371:
yield return 0;
}
yield break;
IL_386:
yield break;
num
num2
unscaledTime
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
