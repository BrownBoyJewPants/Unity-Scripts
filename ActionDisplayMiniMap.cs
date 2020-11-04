using GameCreator.Characters;
using GameCreator.Core;
using GameCreator.Core.Hooks;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionDisplayMiniMap : IAction
{ 
public enum MAPPOSITION
{ 
TopRight,
TopLeft,
BottomLeft,
BottomRight
}

public GameObject mapPanel;

public GameObject mapManager;

public GameObject rawImage;

public GameObject mapcanvas;

public bool overlay;

public bool rotating;

[Range(1f, 60f)]
public float cameraSize = 20f;

public float cameraDistance = 30f;

public bool mapMarkers;

public bool showMarkers;

[Range(0f, 5f)]
public float markerSize = 0.2f;

private PlayerCharacter player;

public ActionDisplayMiniMap.MAPPOSITION mapPosition;

private float mmwidth;

private float mmoffsetx;

private float mmoffsety;

private RectTransform m_RectTransform;

private RenderTexture renderTexture;

private RectTransform rt;

private RawImage img;

private Camera targetCamera;

private MapManager fullscreen;

private GameObject rotatingFrame;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject gameObject = GameObject.Find("MiniMapCamera");
if (this.mapcanvas != null)
{ 
this.mapcanvas.SetActive(false);
}
if (gameObject)
{ 
this.img = null;
this.targetCamera = null;
this.renderTexture = null;
UnityEngine.Object.Destroy(gameObject.gameObject);
}
this.player = IHook<HookPlayer>.Instance.Get<PlayerCharacter>();
this.fullscreen = this.mapManager.GetComponent<MapManager>();
this.fullscreen.miniMapshowing = true;
this.fullscreen.fullMapshowing = false;
if (this.renderTexture == null)
{ 
this.rt = (RectTransform)this.rawImage.transform;
this.renderTexture = new RenderTexture((int)this.rt.rect.width, (int)this.rt.rect.height, 32);
this.renderTexture.Create();
}
if (this.img == null)
{ 
this.img = this.rawImage.gameObject.GetComponent<RawImage>();
this.img.texture = this.renderTexture;
}
if (this.targetCamera == null)
{ 
this.targetCamera = new GameObject
{ 
transform = 
{ 
parent = this.player.transform
}
}.AddComponent<Camera>();
this.targetCamera.enabled = true;
this.targetCamera.allowHDR = false;
this.targetCamera.targetTexture = this.renderTexture;
this.targetCamera.orthographic = true;
this.targetCamera.orthographicSize = this.cameraSize;
this.targetCamera.name = "MiniMapCamera";
this.targetCamera.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y + this.cameraDistance, this.player.transform.position.z);
this.targetCamera.transform.LookAt(this.player.transform);
this.targetCamera.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
}
this.m_RectTransform = this.mapPanel.GetComponent<RectTransform>();
this.m_RectTransform.localScale += new Vector3(0f, 0f, 0f);
this.mmwidth = this.m_RectTransform.rect.width;
this.mmoffsetx = 10f;
this.mmoffsety = 10f;
switch (this.mapPosition)
{ 
case ActionDisplayMiniMap.MAPPOSITION.TopRight: 
this.m_RectTransform.anchoredPosition = new Vector3((float)Screen.width - (this.mmwidth + this.mmoffsetx), (float)Screen.height - (this.mmwidth + this.mmoffsety));
break;
case ActionDisplayMiniMap.MAPPOSITION.TopLeft: 
this.m_RectTransform.anchoredPosition = new Vector3(this.mmoffsetx, (float)Screen.height - (this.mmwidth + this.mmoffsety));
break;
case ActionDisplayMiniMap.MAPPOSITION.BottomLeft: 
this.m_RectTransform.anchoredPosition = new Vector3(this.mmoffsetx, this.mmoffsety);
break;
case ActionDisplayMiniMap.MAPPOSITION.BottomRight: 
this.m_RectTransform.anchoredPosition = new Vector3((float)Screen.width - (this.mmwidth + this.mmoffsetx), this.mmoffsety);
break;
 }
if (this.mapMarkers)
{ 
GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
for (int i = 0; i < array.Length; i++)
{ 
GameObject gameObject2 = array[i];
if (gameObject2.name == "MapMarkerImage")
{ 
gameObject2.transform.localScale = new Vector3(this.markerSize, this.markerSize, this.markerSize);
gameObject2.SetActive(this.showMarkers);
}
}
}
if (!this.rotating)
{ 
this.mapPanel.GetComponentInChildren<FrameRotate>().rotating = false;
}
else
{ 
this.mapPanel.GetComponentInChildren<FrameRotate>().rotating = true;
}
this.mapPanel.SetActive(true);
return true;
gameObject
array
i
gameObject2
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
