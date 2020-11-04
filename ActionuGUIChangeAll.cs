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
public class ActionuGUIChangeAll : IAction
{ 
public enum ALIGN
{ 
Left,
Center,
Right,
Justified
}

public GameObject textObject;

private Text textdata;

public Font font;

public ColorProperty textcolor = new ColorProperty(Color.white);

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public NumberProperty textsize = new NumberProperty(6f);

public NumberProperty outlinewidth = new NumberProperty(0f);

public string content = "";

public ActionuGUIChangeAll.ALIGN alignment;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionuGUIChangeAll.<Execute>d__11))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<Text>();
this.textdata.gameObject.SetActive(false);
this.textdata.color = this.textcolor.GetValue(target);
if (this.textObject.GetComponent<Outline>() == null)
{ 
Outline expr_7D = this.textObject.AddComponent<Outline>();
expr_7D.effectColor = this.outlinecolor.GetValue(target);
Vector2 effectDistance = new Vector2(this.outlinewidth.GetValue(target), -this.outlinewidth.GetValue(target));
expr_7D.effectDistance = effectDistance;
}
else
{ 
Outline expr_D1 = this.textObject.GetComponent<Outline>();
expr_D1.effectColor = this.outlinecolor.GetValue(target);
Vector2 effectDistance2 = new Vector2(this.outlinewidth.GetValue(target), -this.outlinewidth.GetValue(target));
expr_D1.effectDistance = effectDistance2;
}
this.textdata.font = this.font;
this.textdata.fontSize = (int)this.textsize.GetValue(target);
this.textdata.text = this.content;
switch (this.alignment)
{ 
case ActionuGUIChangeAll.ALIGN.Left: 
this.textdata.alignment = TextAnchor.MiddleLeft;
break;
case ActionuGUIChangeAll.ALIGN.Center: 
this.textdata.alignment = TextAnchor.MiddleCenter;
break;
case ActionuGUIChangeAll.ALIGN.Right: 
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
expr_7D
effectDistance
expr_D1
effectDistance2
}
}
}
