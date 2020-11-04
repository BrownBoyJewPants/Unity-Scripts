using GameCreator.Core;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionTMPUIChangeAlignment : IAction
{ 
public enum ALIGN
{ 
Left,
Center,
Right,
Justified
}

public GameObject textObject;

private TextMeshProUGUI textdata;

public ActionTMPUIChangeAlignment.ALIGN alignment;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionTMPUIChangeAlignment.<Execute>d__5))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<TextMeshProUGUI>();
this.textdata.gameObject.SetActive(false);
switch (this.alignment)
{ 
case ActionTMPUIChangeAlignment.ALIGN.Left: 
this.textdata.alignment = TextAlignmentOptions.Left;
break;
case ActionTMPUIChangeAlignment.ALIGN.Center: 
this.textdata.alignment = TextAlignmentOptions.Center;
break;
case ActionTMPUIChangeAlignment.ALIGN.Right: 
this.textdata.alignment = TextAlignmentOptions.Right;
break;
case ActionTMPUIChangeAlignment.ALIGN.Justified: 
this.textdata.alignment = TextAlignmentOptions.Justified;
break;
 }
this.textdata.ForceMeshUpdate();
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
