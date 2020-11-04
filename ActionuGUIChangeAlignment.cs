using GameCreator.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionuGUIChangeAlignment : IAction
{ 
public enum ALIGN
{ 
Left,
Center,
Right
}

public GameObject textObject;

private Text textdata;

public ActionuGUIChangeAlignment.ALIGN alignment;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionuGUIChangeAlignment.<Execute>d__5))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<Text>();
this.textdata.gameObject.SetActive(false);
switch (this.alignment)
{ 
case ActionuGUIChangeAlignment.ALIGN.Left: 
this.textdata.alignment = TextAnchor.MiddleLeft;
break;
case ActionuGUIChangeAlignment.ALIGN.Center: 
this.textdata.alignment = TextAnchor.MiddleCenter;
break;
case ActionuGUIChangeAlignment.ALIGN.Right: 
this.textdata.alignment = TextAnchor.MiddleRight;
break;
 }
this.textdata.gameObject.SetActive(true);
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
