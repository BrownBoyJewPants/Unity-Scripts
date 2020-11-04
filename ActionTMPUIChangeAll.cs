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
public class ActionTMPUIChangeAll : IAction
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

public TMP_FontAsset font;

public ColorProperty textcolor = new ColorProperty(Color.white);

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public NumberProperty textsize = new NumberProperty(6f);

public NumberProperty outlinewidth = new NumberProperty(0f);

public string content = "";

public ActionTMPUIChangeAll.ALIGN alignment;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionTMPUIChangeAll.<Execute>d__11))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<TextMeshProUGUI>();
this.textdata.gameObject.SetActive(false);
this.textdata.font = this.font;
this.textdata.fontSharedMaterial.shaderKeywords = new string[]
{ 
"OUTLINE_ON"
};
this.textdata.color = this.textcolor.GetValue(target);
this.textdata.outlineColor = this.outlinecolor.GetValue(target);
this.textdata.outlineWidth = this.outlinewidth.GetValue(target);
this.textdata.fontSize = this.textsize.GetValue(target);
this.textdata.text = this.content;
switch (this.alignment)
{ 
case ActionTMPUIChangeAll.ALIGN.Left: 
this.textdata.alignment = TextAlignmentOptions.Left;
break;
case ActionTMPUIChangeAll.ALIGN.Center: 
this.textdata.alignment = TextAlignmentOptions.Center;
break;
case ActionTMPUIChangeAll.ALIGN.Right: 
this.textdata.alignment = TextAlignmentOptions.Right;
break;
case ActionTMPUIChangeAll.ALIGN.Justified: 
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
