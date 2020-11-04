using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshChange : IAction
{ 
public enum ALIGN
{ 
Left,
Center,
Right,
Justified
}

public GameObject textObject;

private TextMeshPro textdata;

public TMP_FontAsset font;

public ColorProperty textcolor = new ColorProperty(Color.white);

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public NumberProperty textsize = new NumberProperty(6f);

public NumberProperty outlinewidth = new NumberProperty(1f);

public string content = "";

public Action3DTextMeshChange.ALIGN alignment;

public bool textAutoSize;

public bool textOutline;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(Action3DTextMeshChange.<Execute>d__13))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<TextMeshPro>();
if (this.font != null)
{ 
this.textdata.font = this.font;
}
this.textdata.color = this.textcolor.GetValue(target);
if (this.textOutline)
{ 
this.textdata.outlineColor = this.outlinecolor.GetValue(target);
this.textdata.outlineWidth = this.outlinewidth.GetValue(target);
}
else
{ 
this.textdata.outlineWidth = 0f;
}
if (!this.textAutoSize)
{ 
this.textdata.autoSizeTextContainer = false;
this.textdata.fontSize = this.textsize.GetValue(target);
}
else
{ 
this.textdata.autoSizeTextContainer = true;
}
this.textdata.text = this.content;
switch (this.alignment)
{ 
case Action3DTextMeshChange.ALIGN.Left: 
this.textdata.alignment = TextAlignmentOptions.Left;
break;
case Action3DTextMeshChange.ALIGN.Center: 
this.textdata.alignment = TextAlignmentOptions.Center;
break;
case Action3DTextMeshChange.ALIGN.Right: 
this.textdata.alignment = TextAlignmentOptions.Right;
break;
case Action3DTextMeshChange.ALIGN.Justified: 
this.textdata.alignment = TextAlignmentOptions.Justified;
break;
 }
this.textdata.fontSharedMaterial.EnableKeyword("OUTLINE_ON");
this.textdata.ForceMeshUpdate();
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
