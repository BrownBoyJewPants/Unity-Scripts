using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionAddCanvasVideo : IAction
{ 
public enum VIDEOORIGIN
{ 
Local,
URL
}

public ActionAddCanvasVideo.VIDEOORIGIN videoOrigin;

public VideoClip localVideo;

public StringProperty url = new StringProperty();

public GameObject targetObject;

private RenderTexture renderTexture;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
VideoPlayer videoPlayer = this.targetObject.AddComponent<VideoPlayer>();
AudioSource source = this.targetObject.AddComponent<AudioSource>();
videoPlayer.playOnAwake = false;
ActionAddCanvasVideo.VIDEOORIGIN vIDEOORIGIN = this.videoOrigin;
if (vIDEOORIGIN != ActionAddCanvasVideo.VIDEOORIGIN.Local)
{ 
if (vIDEOORIGIN == ActionAddCanvasVideo.VIDEOORIGIN.URL)
{ 
videoPlayer.url = this.url.GetValue(target);
}
}
else
{ 
videoPlayer.clip = this.localVideo;
}
videoPlayer.renderMode = VideoRenderMode.RenderTexture;
videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
videoPlayer.SetTargetAudioSource(0, source);
if (this.renderTexture == null)
{ 
RectTransform rectTransform = (RectTransform)this.targetObject.transform;
this.renderTexture = new RenderTexture((int)rectTransform.rect.width, (int)rectTransform.rect.height, 32);
this.renderTexture.Create();
}
this.targetObject.gameObject.GetComponent<RawImage>().texture = this.renderTexture;
videoPlayer.renderMode = VideoRenderMode.RenderTexture;
videoPlayer.targetTexture = this.renderTexture;
return true;
videoPlayer
source
vIDEOORIGIN
rectTransform
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
