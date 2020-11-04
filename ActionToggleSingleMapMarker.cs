using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionToggleSingleMapMarker : IAction
{ 
private Transform markerObject;

public TargetGameObject target = new TargetGameObject();

public bool showing;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject gameObject = this.target.GetGameObject(target);
this.markerObject = gameObject.transform.Find("MapMarkerImage");
this.markerObject.gameObject.SetActive(this.showing);
return true;
gameObject
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
