using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionBlinkMapMarker : IAction
{ 
public GameObject marker;

private Transform markerObject;

public NumberProperty repeating = new NumberProperty(0.5f);

public TargetGameObject target = new TargetGameObject();

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject gameObject = this.target.GetGameObject(target);
this.markerObject = gameObject.gameObject.transform.Find("MapMarkerImage");
float value = this.repeating.GetValue(target);
if (this.markerObject != null)
{ 
base.InvokeRepeating("Blink", 0.5f, value);
}
return true;
gameObject
value
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void Blink()
{ 
MeshRenderer component = this.markerObject.GetComponent<MeshRenderer>();
if (component.enabled)
{ 
component.enabled = false;
return;
}
component.enabled = true;
component
}

public void StopRepeating()
{ 
base.CancelInvoke("Blink");
}
}
}
