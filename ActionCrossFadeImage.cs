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
public class ActionCrossFadeImage : IAction
{ 
public GameObject canvasImage;

private Image image;

private Color curColor;

[Range(0f, 5f)]
public float duration = 0.5f;

public NumberProperty alpha = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionCrossFadeImage.<Execute>d__6))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.image = this.canvasImage.GetComponent<Image>();
if (this.image != null)
{ 
float value = this.alpha.GetValue(target);
Color arg_5A_0 = this.image.color;
float arg_60_0 = Time.unscaledTime;
this.image.CrossFadeAlpha(value, this.duration, false);
}
yield return 0;
}
if (num != 1)
{ 
yield break;
}
yield break;
num
value
arg_5A_0
arg_60_0
}
}
}
