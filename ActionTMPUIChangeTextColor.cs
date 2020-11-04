using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionTMPUIChangeTextColor : IAction
{ 
public GameObject textObject;

private TextMeshProUGUI textdata;

public ColorProperty textcolor = new ColorProperty(Color.white);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionTMPUIChangeTextColor.<Execute>d__4))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<TextMeshProUGUI>();
this.textdata.gameObject.SetActive(false);
this.textdata.color = this.textcolor.GetValue(target);
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
