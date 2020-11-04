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
public class ActionTMPUICrossFadeText : IAction
{ 
public GameObject canvasText;

private TextMeshProUGUI text;

private Color curColor;

[Range(0f, 5f)]
public float duration = 0.5f;

public NumberProperty alpha = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionTMPUICrossFadeText.<Execute>d__6))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.text = this.canvasText.GetComponent<TextMeshProUGUI>();
if (this.text != null)
{ 
float value = this.alpha.GetValue(target);
Color arg_5A_0 = this.text.color;
float arg_60_0 = Time.unscaledTime;
this.text.CrossFadeAlpha(value, this.duration, false);
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
