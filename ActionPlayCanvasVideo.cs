using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionPlayCanvasVideo : IAction
{ 
public GameObject targetObject;

public NumberProperty firstframe = new NumberProperty(0f);

public bool loopVideo;

public bool waitforFirst = true;

[Range(0f, 10f)]
public float speed = 1f;

[Range(0f, 1f)]
public float volume = 1f;

[Range(0f, 1f)]
public float blend;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
AudioSource arg_26_0 = this.targetObject.GetComponent<AudioSource>();
VideoPlayer component = this.targetObject.GetComponent<VideoPlayer>();
if (this.loopVideo)
{ 
component.isLooping = true;
}
arg_26_0.spatialBlend = this.blend;
arg_26_0.priority = 0;
arg_26_0.volume = this.volume;
component.waitForFirstFrame = this.waitforFirst;
component.playbackSpeed = this.speed;
long frame = (long)this.firstframe.GetValue(target);
component.frame = frame;
component.Play();
return true;
arg_26_0
component
frame
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
