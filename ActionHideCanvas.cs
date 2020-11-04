using GameCreator.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionHideCanvas : IAction
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

public bool hide = true;

public ActionHideCanvas.ALIGN alignment;

public Vector3 AnimOutPositionTop;

public Vector3 AnimOutPositionBottom;

public Vector3 AnimOutPositionLeft;

public Vector3 AnimOutPositionRight;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionHideCanvas.<Execute>d__10))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.animpanel = this.canvasPanel.GetComponent<RectTransform>();
this.AnimOutPositionTop = new Vector3(0f, (float)Screen.height, 0f);
this.AnimOutPositionBottom = new Vector3(0f, (float)(-(float)Screen.height), 0f);
this.AnimOutPositionLeft = new Vector3((float)(-(float)Screen.width), 0f, 0f);
this.AnimOutPositionRight = new Vector3((float)Screen.width, 0f, 0f);
if (!this.hide)
{ 
this.animpanel.localPosition = new Vector3(0f, 0f, 0f);
}
else
{ 
switch (this.alignment)
{ 
case ActionHideCanvas.ALIGN.Top: 
this.animpanel.localPosition = this.AnimOutPositionTop;
break;
case ActionHideCanvas.ALIGN.Bottom: 
this.animpanel.localPosition = this.AnimOutPositionBottom;
break;
case ActionHideCanvas.ALIGN.Left: 
this.animpanel.localPosition = this.AnimOutPositionLeft;
break;
case ActionHideCanvas.ALIGN.Right: 
this.animpanel.localPosition = this.AnimOutPositionRight;
break;
 }
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
