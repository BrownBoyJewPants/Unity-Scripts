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
public class ActionDisplayMapFullScreen : IAction
{ 
public GameObject mapManager;

public GameObject mapPanel;

public GameObject rawImage;

public GameObject mapcanvas;

[Range(1f, 1500f)]
public float cameraSize = 20f;

[Range(1f, 100f)]
public float cameraDistance = 30f;

[Range(1f, 60f)]
public float planedistance = 10f;

private PlayerCharacter player;

private float mmwidth;

private float mmoffsetx;

private float mmoffsety;

private RectTransform m_RectTransform;

private Image mask;

private RenderTexture renderTexture;

private RectTransform rt;

private RawImage img;

private Camera targetCamera;

public MapManager fullscreen;

public bool mapMarkers;

public bool showMarkers;

[Range(0f, 5f)]
public float markerSize = 0.2f;

public bool overlay;

public bool lockMap;

public bool centerMap;

public GameObject mapCenter;

public bool overlayMap;

public bool zoomMap;

public bool dragMap;

[Range(0f, 2f)]
public int dragbutton;

[Range(1f, 10f)]
public int dragspeed = 1;

[Range(1f, 20f)]
public float zoomSensitivity = 5f;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject gameObject = GameObject.Find("MiniMapCamera");
if (gameObject)
{ 
this.img = null;
this.targetCamera = null;
this.renderTexture = null;
UnityEngine.Object.Destroy(gameObject.gameObject);
}
this.player = IHook<HookPlayer>.Instance.Get<PlayerCharacter>();
this.fullscreen = this.mapManager.GetComponent<MapManager>();
this.fullscreen.miniMapshowing = false;
this.fullscreen.fullMapshowing = true;
this.fullscreen.miniMapscrollWheel = this.zoomMap;
this.fullscreen.miniMapscrollWheelSpeed = this.zoomSensitivity;
this.fullscreen.miniMapmouseDrag = this.dragMap;
this.fullscreen.miniMapDragButton = this.dragbutton;
this.fullscreen.miniMapDragSpeed = this.dragspeed;
if (this.renderTexture != null)
{ 
this.renderTexture.Release();
this.rt = (RectTransform)this.rawImage.transform;
this.renderTexture = new RenderTexture(Screen.width, Screen.height, 32);
this.renderTexture.Create();
}
if (this.img == null)
{ 
this.img = this.rawImage.gameObject.GetComponent<RawImage>();
this.img.texture = this.renderTexture;
}
this.m_RectTransform = this.mapPanel.GetComponent<RectTransform>();
this.m_RectTransform.localScale += new Vector3(0f, 0f, 0f);
this.mmwidth = this.m_RectTransform.rect.width;
if (this.mapPanel != null)
{ 
this.mapPanel.SetActive(false);
}
if (this.targetCamera == null)
{ 
GameObject gameObject2 = new GameObject();
if (!this.lockMap)
{ 
gameObject2.transform.parent = this.player.transform;
}
this.targetCamera = gameObject2.AddComponent<Camera>();
this.targetCamera.enabled = true;
this.targetCamera.allowHDR = false;
this.targetCamera.targetTexture = this.renderTexture;
this.targetCamera.orthographic = true;
this.targetCamera.orthographicSize = this.cameraSize;
this.targetCamera.name = "MiniMapCamera";
this.targetCamera.transform.LookAt(this.player.transform);
this.targetCamera.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
this.targetCamera.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y + this.cameraDistance, this.player.transform.position.z);
if (this.centerMap && this.mapCenter != null)
{ 
this.targetCamera.transform.position = new Vector3(this.mapCenter.transform.position.x, this.mapCenter.transform.position.y + this.cameraDistance, this.mapCenter.transform.position.z);
}
}
if (this.mapMarkers)
{ 
GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
for (int i = 0; i < array.Length; i++)
{ 
GameObject gameObject3 = array[i];
if (gameObject3.name == "MapMarkerImage")
{ 
gameObject3.transform.localScale = new Vector3(this.markerSize, this.markerSize, this.markerSize);
gameObject3.SetActive(this.showMarkers);
}
}
}
if (this.overlay && this.mapcanvas != null)
{ 
if (this.overlayMap)
{ 
this.mapcanvas.SetActive(true);
Canvas expr_3FB = this.mapcanvas.gameObject.GetComponent<Canvas>();
expr_3FB.renderMode = RenderMode.ScreenSpaceCamera;
expr_3FB.worldCamera = this.targetCamera;
expr_3FB.planeDistance = this.planedistance;
}
else
{ 
this.mapcanvas.SetActive(false);
}
}
return true;
gameObject
gameObject2
array
i
gameObject3
expr_3FB
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
