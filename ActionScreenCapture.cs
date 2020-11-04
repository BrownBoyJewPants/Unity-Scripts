using GameCreator.Core;
using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.Tools
{ 
[AddComponentMenu("")]
public class ActionScreenCapture : IAction
{ 
public enum CAPTURE
{ 
LowRes,
HighRes,
Thumbnail
}

public enum ENCODE
{ 
png,
jpg,
tga
}

public ActionScreenCapture.CAPTURE imageMode;

public ActionScreenCapture.ENCODE imageformat;

public string imagePath;

public bool logdata;

[Range(0f, 10f), SerializeField]
public float timer;

[Range(0f, 60f), SerializeField]
public float repeat;

[Range(1f, 20f), SerializeField]
public int imagesize = 1;

public TargetGameObject target = new TargetGameObject();

public Actions actions;

private byte[] imageBytes;

private string screenShot;

private int resWidth = Screen.width * 4;

private int resHeight = Screen.height * 4;

public Camera camera;

private int scale = 1;

private RenderTexture renderTexture;

private bool resizeimage;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
switch (this.imageMode)
{ 
case ActionScreenCapture.CAPTURE.LowRes: 
this.resizeimage = false;
if (this.repeat > 0f)
{ 
base.InvokeRepeating("captureLoRes", 0f, this.repeat);
}
else
{ 
this.captureLoRes();
}
break;
case ActionScreenCapture.CAPTURE.HighRes: 
this.resizeimage = false;
if (this.repeat > 0f)
{ 
base.InvokeRepeating("captureHiRes", 0f, this.repeat);
}
else
{ 
this.captureHiRes();
}
break;
case ActionScreenCapture.CAPTURE.Thumbnail: 
this.resizeimage = true;
if (this.repeat > 0f)
{ 
base.InvokeRepeating("captureLoRes", 0f, this.repeat);
}
else
{ 
this.captureLoRes();
}
break;
 }
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void captureLoRes()
{ 
base.StartCoroutine(this.captureScreenshot());
}

private void captureHiRes()
{ 
base.StartCoroutine(this.captureHiResScreenshot());
}

public void StopRepeating()
{ 
base.CancelInvoke("captureLoRes");
base.CancelInvoke("captureHiRes");
base.CancelInvoke("captureThumbnail");
}

[IteratorStateMachine(typeof(ActionScreenCapture.<captureScreenshot>d__24))]
private IEnumerator captureScreenshot()
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0: 
yield return new WaitForSeconds(this.timer);
continue;
case 1: 
yield return new WaitForEndOfFrame();
continue;
case 2: 
goto IL_5E;
 }
break;
}
yield break;
IL_5E:
this.screenShot = string.Format("{0}{1}{2}{3}", new object[]
{ 
this.imagePath,
DateTime.Now.Ticks,
".",
this.imageformat
});
Texture2D texture2D = new Texture2D(Screen.width, Screen.height);
texture2D.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0);
texture2D.Apply();
if (this.resizeimage)
{ 
texture2D = ActionScreenCapture.Resize(texture2D, texture2D.width / this.imagesize, texture2D.height / this.imagesize);
}
switch (this.imageformat)
{ 
case ActionScreenCapture.ENCODE.png: 
this.imageBytes = texture2D.EncodeToPNG();
break;
case ActionScreenCapture.ENCODE.jpg: 
this.imageBytes = texture2D.EncodeToJPG();
break;
case ActionScreenCapture.ENCODE.tga: 
this.imageBytes = texture2D.EncodeToTGA();
break;
 }
if (Application.isMobilePlatform)
{ 
File.WriteAllBytes(Application.persistentDataPath + "/" + this.screenShot, this.imageBytes);
}
else
{ 
File.WriteAllBytes(this.screenShot, this.imageBytes);
}
if (this.logdata)
{ 
Debug.Log("screenImage.width" + texture2D.width);
Debug.Log("imagesBytes=" + this.imageBytes.Length);
Debug.Log("imagePath=" + this.screenShot);
}
yield break;
num
texture2D
}

[IteratorStateMachine(typeof(ActionScreenCapture.<captureHiResScreenshot>d__25))]
private IEnumerator captureHiResScreenshot()
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0: 
yield return new WaitForSeconds(this.timer);
continue;
case 1: 
yield return new WaitForEndOfFrame();
continue;
case 2: 
goto IL_5E;
 }
break;
}
yield break;
IL_5E:
this.screenShot = string.Format("{0}{1}{2}{3}", new object[]
{ 
this.imagePath,
DateTime.Now.Ticks,
".",
this.imageformat
});
int num2 = this.resWidth * this.scale;
int num3 = this.resHeight * this.scale;
RenderTexture renderTexture = new RenderTexture(num2, num3, 24);
this.camera.targetTexture = renderTexture;
Texture2D texture2D = new Texture2D(num2, num3, TextureFormat.RGB24, false);
this.camera.Render();
RenderTexture.active = renderTexture;
texture2D.ReadPixels(new Rect(0f, 0f, (float)num2, (float)num3), 0, 0);
this.camera.targetTexture = null;
RenderTexture.active = null;
switch (this.imageformat)
{ 
case ActionScreenCapture.ENCODE.png: 
this.imageBytes = texture2D.EncodeToPNG();
break;
case ActionScreenCapture.ENCODE.jpg: 
this.imageBytes = texture2D.EncodeToJPG();
break;
case ActionScreenCapture.ENCODE.tga: 
this.imageBytes = texture2D.EncodeToTGA();
break;
 }
if (Application.isMobilePlatform)
{ 
File.WriteAllBytes(Application.persistentDataPath + "/" + this.screenShot, this.imageBytes);
}
else
{ 
File.WriteAllBytes(this.screenShot, this.imageBytes);
}
if (this.logdata)
{ 
Debug.Log("HiResImage.width" + texture2D.width);
Debug.Log("imagesBytes=" + this.imageBytes.Length);
Debug.Log("imagePath=" + this.screenShot);
}
yield break;
num
num2
num3
renderTexture
texture2D
}

public static Texture2D Resize(Texture2D source, int newWidth, int newHeight)
{ 
source.filterMode = FilterMode.Point;
RenderTexture temporary = RenderTexture.GetTemporary(newWidth, newHeight);
temporary.filterMode = FilterMode.Point;
RenderTexture.active = temporary;
Graphics.Blit(source, temporary);
Texture2D expr_2A = new Texture2D(newWidth, newHeight);
expr_2A.ReadPixels(new Rect(0f, 0f, (float)newWidth, (float)newHeight), 0, 0);
expr_2A.Apply();
RenderTexture.active = null;
RenderTexture.ReleaseTemporary(temporary);
return expr_2A;
temporary
expr_2A
}
}
}
