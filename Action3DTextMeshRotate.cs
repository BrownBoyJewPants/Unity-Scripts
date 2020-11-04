using GameCreator.Core;
using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshRotate : IAction
{ 
public GameObject textObject;

private TextMeshPro textdata;

public TargetPosition lookAt = new TargetPosition(TargetPosition.Target.Invoker);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return false;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
Vector3 forward = this.textObject.transform.position - this.lookAt.GetPosition(target, Space.World);
this.textObject.transform.rotation = Quaternion.LookRotation(forward);
return base.Execute(target, actions, index);
forward
}
}
}
