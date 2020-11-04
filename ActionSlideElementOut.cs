using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionSlideElementOut : IAction
{ 
public enum ALIGN
{ 
Top,
Bottom,
Left,
Right,
TopLeftCorner,
TopRightCorner,
BottomLeftCorner,
BottomRightCorner
}

public GameObject canvasElement;

public RectTransform animElement;

public ActionSlideElementOut.ALIGN alignment;

public NumberProperty AnimateDuration = new NumberProperty(1f);

public Easing.EaseType easing = Easing.EaseType.QuadInOut;

public Vector3 animStartPosition;

public Vector3 AnimInPosition;

public Vector3 AnimOutPositionTop;

public Vector3 AnimOutPositionBottom;

public Vector3 AnimOutPositionLeft;

public Vector3 AnimOutPositionRight;

public Vector3 AnimOutPositionTopLeft;

public Vector3 AnimOutPositionTopRight;

public Vector3 AnimOutPositionBottomLeft;

public Vector3 AnimOutPositionBottomRight;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionSlideElementOut.<Execute>d__17))]
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
this.animElement = this.canvasElement.GetComponent<RectTransform>();
this.animStartPosition = this.animElement.localPosition;
this.AnimOutPositionTop = new Vector3(this.animElement.localPosition.x, (float)Screen.height, this.animElement.localPosition.z);
this.AnimOutPositionBottom = new Vector3(this.animElement.localPosition.x, (float)(-(float)Screen.height), this.animElement.localPosition.z);
this.AnimOutPositionLeft = new Vector3((float)(-(float)Screen.width), this.animElement.localPosition.y, this.animElement.localPosition.z);
this.AnimOutPositionRight = new Vector3((float)Screen.width, this.animElement.localPosition.y, this.animElement.localPosition.z);
this.AnimOutPositionTopLeft = new Vector3((float)Screen.width, (float)Screen.height, this.animElement.localPosition.z);
this.AnimOutPositionTopRight = new Vector3((float)(-(float)Screen.width), (float)Screen.height, this.animElement.localPosition.z);
this.AnimOutPositionBottomRight = new Vector3((float)Screen.width, (float)(-(float)Screen.height), this.animElement.localPosition.z);
this.AnimOutPositionBottomLeft = new Vector3((float)(-(float)Screen.width), (float)(-(float)Screen.height), this.animElement.localPosition.z);
num2 = this.AnimateDuration.GetValue(target);
if (num2 < 0.2f)
{ 
num2 = 0.2f;
}
unscaledTime = Time.unscaledTime;
switch (this.alignment)
{ 
case ActionSlideElementOut.ALIGN.Top: 
goto IL_2AB;
case ActionSlideElementOut.ALIGN.Bottom: 
goto IL_33B;
case ActionSlideElementOut.ALIGN.Left: 
goto IL_3CB;
case ActionSlideElementOut.ALIGN.Right: 
goto IL_45B;
case ActionSlideElementOut.ALIGN.TopLeftCorner: 
goto IL_4EB;
case ActionSlideElementOut.ALIGN.TopRightCorner: 
goto IL_57B;
case ActionSlideElementOut.ALIGN.BottomLeftCorner: 
goto IL_60B;
case ActionSlideElementOut.ALIGN.BottomRightCorner: 
goto IL_698;
default: 
goto IL_6AF;
 }
break;
case 1: 
goto IL_2AB;
case 2: 
goto IL_33B;
case 3: 
goto IL_3CB;
case 4: 
goto IL_45B;
case 5: 
goto IL_4EB;
case 6: 
goto IL_57B;
case 7: 
goto IL_60B;
case 8: 
goto IL_698;
case 9: 
goto IL_6C5;
 }
break;
IL_2AB:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t = (Time.unscaledTime - unscaledTime) / num2;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionTop, ease);
yield return null;
continue;
}
goto IL_6AF;
IL_33B:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t2 = (Time.unscaledTime - unscaledTime) / num2;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionBottom, ease2);
yield return null;
continue;
}
goto IL_6AF;
IL_3CB:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t3 = (Time.unscaledTime - unscaledTime) / num2;
float ease3 = Easing.GetEase(this.easing, 0f, 1f, t3);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionLeft, ease3);
yield return null;
continue;
}
goto IL_6AF;
IL_45B:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t4 = (Time.unscaledTime - unscaledTime) / num2;
float ease4 = Easing.GetEase(this.easing, 0f, 1f, t4);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionRight, ease4);
yield return null;
continue;
}
goto IL_6AF;
IL_4EB:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t5 = (Time.unscaledTime - unscaledTime) / num2;
float ease5 = Easing.GetEase(this.easing, 0f, 1f, t5);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionTopLeft, ease5);
yield return null;
continue;
}
goto IL_6AF;
IL_57B:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t6 = (Time.unscaledTime - unscaledTime) / num2;
float ease6 = Easing.GetEase(this.easing, 0f, 1f, t6);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionTopRight, ease6);
yield return null;
continue;
}
goto IL_6AF;
IL_60B:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6AF;
}
if (!(this.animElement == null))
{ 
float t7 = (Time.unscaledTime - unscaledTime) / num2;
float ease7 = Easing.GetEase(this.easing, 0f, 1f, t7);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionBottomLeft, ease7);
yield return null;
continue;
}
goto IL_6AF;
IL_698:
if (Time.unscaledTime - unscaledTime < num2 && !(this.animElement == null))
{ 
float t8 = (Time.unscaledTime - unscaledTime) / num2;
float ease8 = Easing.GetEase(this.easing, 0f, 1f, t8);
this.animElement.localPosition = Vector3.Lerp(this.animStartPosition, this.AnimOutPositionBottomRight, ease8);
yield return null;
continue;
}
IL_6AF:
yield return 0;
}
yield break;
IL_6C5:
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
t5
ease5
t6
ease6
t7
ease7
t8
ease8
}
}
}
