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
public class ActionCrossFadePanel : IAction
{ 
public GameObject canvasPanel;

private Image image;

private Text text;

private Dropdown dropdown;

private SliderVariable slider;

private ToggleVariable toggle;

private ButtonActions button;

private Color curColor;

[Range(0f, 2f)]
public float duration = 0.5f;

public NumberProperty alpha = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionCrossFadePanel.<Execute>d__11))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0: 
this.canvasPanel.SetActive(true);
this.text = this.canvasPanel.GetComponentInChildren<Text>();
this.image = this.canvasPanel.GetComponent<Image>();
this.dropdown = this.canvasPanel.GetComponent<Dropdown>();
this.slider = this.canvasPanel.GetComponent<SliderVariable>();
this.toggle = this.canvasPanel.GetComponent<ToggleVariable>();
this.button = this.canvasPanel.GetComponent<ButtonActions>();
if (this.text != null)
{ 
float value = this.alpha.GetValue(target);
Color arg_C6_0 = this.text.color;
float arg_CC_0 = Time.unscaledTime;
this.text.CrossFadeAlpha(value, this.duration, false);
}
if (this.image != null)
{ 
float value2 = this.alpha.GetValue(target);
Color arg_10C_0 = this.image.color;
float arg_112_0 = Time.unscaledTime;
this.image.CrossFadeAlpha(value2, this.duration, false);
}
yield return new WaitForSeconds(this.duration);
continue;
case 1:
{ 
float value3 = this.alpha.GetValue(target);
if (value3 == 0f)
{ 
if (this.dropdown != null)
{ 
this.dropdown.interactable = false;
this.dropdown.enabled = false;
}
if (this.slider != null)
{ 
this.slider.interactable = false;
this.slider.enabled = false;
}
if (this.toggle != null)
{ 
this.toggle.interactable = false;
this.toggle.enabled = false;
}
if (this.button != null)
{ 
this.button.interactable = false;
}
this.canvasPanel.SetActive(false);
}
else if (value3 > 0f)
{ 
if (this.dropdown != null)
{ 
this.dropdown.interactable = true;
this.dropdown.enabled = true;
}
if (this.slider != null)
{ 
this.slider.interactable = true;
this.slider.enabled = true;
}
if (this.toggle != null)
{ 
this.toggle.interactable = true;
this.toggle.enabled = true;
}
if (this.button != null)
{ 
this.button.interactable = true;
}
this.canvasPanel.SetActive(true);
}
yield return 0;
continue;
}
case 2: 
goto IL_2BA;
 }
break;
}
yield break;
IL_2BA:
yield break;
num
value
arg_C6_0
arg_CC_0
value2
arg_10C_0
arg_112_0
value3
}
}
}
