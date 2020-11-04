using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionHideElement : IAction
{ 
public enum ALIGN
{ 
Top,
Bottom,
Left,
Right
}

public GameObject canvasElement;

public RectTransform animElement;

public ActionHideElement.ALIGN alignment;

public Vector3 AnimOutPositionTop;

public Vector3 AnimOutPositionBottom;

public Vector3 AnimOutPositionLeft;

public Vector3 AnimOutPositionRight;

public StringProperty originalPos;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionHideElement.<Execute>d__10))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.animElement = this.canvasElement.GetComponent<RectTransform>();
VariablesManager.SetLocal(this.canvasElement, "originalPosition", this.animElement.localPosition, true);
this.AnimOutPositionTop = new Vector3(this.animElement.localPosition.x, (float)Screen.height, this.animElement.localPosition.z);
this.AnimOutPositionBottom = new Vector3(this.animElement.localPosition.x, (float)(-(float)Screen.height), this.animElement.localPosition.z);
this.AnimOutPositionLeft = new Vector3((float)(-(float)Screen.width), this.animElement.localPosition.y, this.animElement.localPosition.z);
this.AnimOutPositionRight = new Vector3((float)Screen.width, this.animElement.localPosition.y, this.animElement.localPosition.z);
switch (this.alignment)
{ 
case ActionHideElement.ALIGN.Top: 
this.animElement.localPosition = this.AnimOutPositionTop;
break;
case ActionHideElement.ALIGN.Bottom: 
this.animElement.localPosition = this.AnimOutPositionBottom;
break;
case ActionHideElement.ALIGN.Left: 
this.animElement.localPosition = this.AnimOutPositionLeft;
break;
case ActionHideElement.ALIGN.Right: 
this.animElement.localPosition = this.AnimOutPositionRight;
break;
 }
yield return 0;
}
if (num != 1)
{ 
yield break;
}
yield break;
num
}
}
}
