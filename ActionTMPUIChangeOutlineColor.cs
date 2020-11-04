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
public class ActionTMPUIChangeOutlineColor : IAction
{ 
public GameObject textObject;

private TextMeshProUGUI textdata;

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

[IteratorStateMachine(typeof(ActionTMPUIChangeOutlineColor.<Execute>d__4))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
int num;
while (num == 0)
{ 
this.textdata = this.textObject.GetComponent<TextMeshProUGUI>();
this.textdata.gameObject.SetActive(false);
this.textdata.fontSharedMaterial.shaderKeywords = new string[]
{ 
"OUTLINE_ON"
};
this.textdata.outlineColor = this.outlinecolor.GetValue(target);
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
