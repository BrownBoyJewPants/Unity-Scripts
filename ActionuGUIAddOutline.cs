using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionuGUIAddOutline : IAction
{ 
public GameObject textObject;

private Text textdata;

public NumberProperty outlinewidth = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionuGUIAddOutline.<Execute>d__4))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
if (this.textObject.GetComponent<Outline>() == null)
{ 
Shadow arg_6A_0 = this.textObject.AddComponent<Outline>();
Vector2 effectDistance = new Vector2(this.outlinewidth.GetValue(target), -this.outlinewidth.GetValue(target));
arg_6A_0.effectDistance = effectDistance;
}
if (this.outlinewidth.GetValue(target) == 0f)
{ 
UnityEngine.Object.Destroy(this.textObject.GetComponent<Outline>());
}
yield return 0;
}
if (num != 1)
{ 
yield break;
}
yield break;
num
arg_6A_0
effectDistance
}
}
}
