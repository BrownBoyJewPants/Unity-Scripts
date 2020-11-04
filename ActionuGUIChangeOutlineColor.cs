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
public class ActionuGUIChangeOutlineColor : IAction
{ 
public GameObject textObject;

private Text textdata;

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionuGUIChangeOutlineColor.<Execute>d__4))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
if (this.textObject.GetComponent<Outline>() == null)
{ 
this.textObject.AddComponent<Outline>().effectColor = this.outlinecolor.GetValue(target);
}
else
{ 
this.textObject.GetComponent<Outline>().effectColor = this.outlinecolor.GetValue(target);
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
