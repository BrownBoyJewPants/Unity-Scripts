using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionStopBlinkMapMarker : IAction
{ 
public TargetGameObject target = new TargetGameObject();

public Actions actions;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
ActionBlinkMapMarker[] components = this.actions.gameObject.GetComponents<ActionBlinkMapMarker>();
for (int i = 0; i < components.Length; i++)
{ 
components[i].StopRepeating();
}
this.target.GetGameObject(target).gameObject.transform.Find("MapMarkerImage").GetComponent<MeshRenderer>().enabled = true;
return true;
components
i
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
