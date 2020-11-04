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
public class ActionCrossFadeButton : IAction
{ 
public GameObject canvasButton;

private Image image;

private Text text;

private ButtonActions button;

private Color curColor;

[Range(0f, 2f)]
public float duration = 0.5f;

public NumberProperty alpha = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionCrossFadeButton.<Execute>d__8))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0: 
this.text = this.canvasButton.GetComponentInChildren<Text>();
this.image = this.canvasButton.GetComponent<Image>();
this.button = this.canvasButton.GetComponent<ButtonActions>();
this.canvasButton.SetActive(true);
if (this.button != null)
{ 
if (this.text != null)
{ 
float value = this.alpha.GetValue(target);
Color arg_A4_0 = this.text.color;
float arg_AA_0 = Time.unscaledTime;
this.text.CrossFadeAlpha(value, this.duration, false);
}
if (this.image != null)
{ 
float value2 = this.alpha.GetValue(target);
Color arg_EA_0 = this.image.color;
float arg_F0_0 = Time.unscaledTime;
this.image.CrossFadeAlpha(value2, this.duration, false);
}
yield return new WaitForSeconds(this.duration);
continue;
}
goto IL_17A;
case 1:
{ 
float value3 = this.alpha.GetValue(target);
if (value3 == 0f)
{ 
this.button.interactable = false;
this.canvasButton.SetActive(false);
goto IL_17A;
}
if (value3 == 1f)
{ 
this.button.interactable = true;
this.canvasButton.SetActive(true);
goto IL_17A;
}
goto IL_17A;
}
case 2: 
goto IL_18F;
 }
break;
IL_17A:
yield return 0;
}
yield break;
IL_18F:
yield break;
num
value
arg_A4_0
arg_AA_0
value2
arg_EA_0
arg_F0_0
value3
}
}
}
