using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionSlideElementIn : IAction
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

public ActionSlideElementIn.ALIGN alignment;

public NumberProperty AnimateDuration = new NumberProperty(1f);

public Easing.EaseType easing = Easing.EaseType.BackInOut;

public Vector3 OriginalStartPosition;

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

[IteratorStateMachine(typeof(ActionSlideElementIn.<Execute>d__18))]
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
this.animElement = this.canvasElement.GetComponent<RectTransform>();
object local = VariablesManager.GetLocal(this.canvasElement, "originalPosition", true);
this.OriginalStartPosition = (Vector3)local;
this.AnimInPosition = new Vector3(this.OriginalStartPosition.x, this.OriginalStartPosition.y, this.OriginalStartPosition.z);
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
case ActionSlideElementIn.ALIGN.Top: 
goto IL_2E6;
case ActionSlideElementIn.ALIGN.Bottom: 
goto IL_376;
case ActionSlideElementIn.ALIGN.Left: 
goto IL_406;
case ActionSlideElementIn.ALIGN.Right: 
goto IL_496;
case ActionSlideElementIn.ALIGN.TopLeftCorner: 
goto IL_526;
case ActionSlideElementIn.ALIGN.TopRightCorner: 
goto IL_5B6;
case ActionSlideElementIn.ALIGN.BottomLeftCorner: 
goto IL_646;
case ActionSlideElementIn.ALIGN.BottomRightCorner: 
goto IL_6D3;
default: 
goto IL_6EA;
 }
break;
}
case 1: 
goto IL_2E6;
case 2: 
goto IL_376;
case 3: 
goto IL_406;
case 4: 
goto IL_496;
case 5: 
goto IL_526;
case 6: 
goto IL_5B6;
case 7: 
goto IL_646;
case 8: 
goto IL_6D3;
case 9: 
goto IL_704;
 }
break;
IL_2E6:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t = (Time.unscaledTime - unscaledTime) / num2;
float ease = Easing.GetEase(this.easing, 0f, 1f, t);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionTop, this.AnimInPosition, ease);
yield return null;
continue;
}
goto IL_6EA;
IL_376:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t2 = (Time.unscaledTime - unscaledTime) / num2;
float ease2 = Easing.GetEase(this.easing, 0f, 1f, t2);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionBottom, this.AnimInPosition, ease2);
yield return null;
continue;
}
goto IL_6EA;
IL_406:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t3 = (Time.unscaledTime - unscaledTime) / num2;
float ease3 = Easing.GetEase(this.easing, 0f, 1f, t3);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionLeft, this.AnimInPosition, ease3);
yield return null;
continue;
}
goto IL_6EA;
IL_496:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t4 = (Time.unscaledTime - unscaledTime) / num2;
float ease4 = Easing.GetEase(this.easing, 0f, 1f, t4);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionRight, this.AnimInPosition, ease4);
yield return null;
continue;
}
goto IL_6EA;
IL_526:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t5 = (Time.unscaledTime - unscaledTime) / num2;
float ease5 = Easing.GetEase(this.easing, 0f, 1f, t5);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionTopLeft, this.AnimInPosition, ease5);
yield return null;
continue;
}
goto IL_6EA;
IL_5B6:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t6 = (Time.unscaledTime - unscaledTime) / num2;
float ease6 = Easing.GetEase(this.easing, 0f, 1f, t6);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionTopRight, this.AnimInPosition, ease6);
yield return null;
continue;
}
goto IL_6EA;
IL_646:
if (Time.unscaledTime - unscaledTime >= num2)
{ 
goto IL_6EA;
}
if (!(this.animElement == null))
{ 
float t7 = (Time.unscaledTime - unscaledTime) / num2;
float ease7 = Easing.GetEase(this.easing, 0f, 1f, t7);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionBottomLeft, this.AnimInPosition, ease7);
yield return null;
continue;
}
goto IL_6EA;
IL_6D3:
if (Time.unscaledTime - unscaledTime < num2 && !(this.animElement == null))
{ 
float t8 = (Time.unscaledTime - unscaledTime) / num2;
float ease8 = Easing.GetEase(this.easing, 0f, 1f, t8);
this.animElement.localPosition = Vector3.Lerp(this.AnimOutPositionBottomRight, this.AnimInPosition, ease8);
yield return null;
continue;
}
IL_6EA:
yield return new WaitForSeconds(0.2f);
}
yield break;
IL_704:
yield break;
num
local
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
