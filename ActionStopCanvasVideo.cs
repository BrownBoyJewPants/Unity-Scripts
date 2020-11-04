using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionStopCanvasVideo : IAction
{ 
public GameObject targetObject;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.targetObject.GetComponent<VideoPlayer>().Stop();
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
