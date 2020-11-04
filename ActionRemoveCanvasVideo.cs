using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionRemoveCanvasVideo : IAction
{ 
public GameObject targetObject;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
VideoPlayer arg_17_0 = this.targetObject.GetComponent<VideoPlayer>();
AudioSource component = this.targetObject.GetComponent<AudioSource>();
arg_17_0.targetTexture.Release();
UnityEngine.Object.Destroy(arg_17_0);
UnityEngine.Object.Destroy(component);
return true;
arg_17_0
component
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
