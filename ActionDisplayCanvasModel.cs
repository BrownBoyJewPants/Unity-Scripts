using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionDisplayCanvasModel : IAction
{ 
public LayerMask objectImageLayer;

public LightType objectLight;

public GameObject targetObject;

public GameObjectProperty targetModel = new GameObjectProperty();

public bool spinObject;

public bool dragObject;

public bool outlineObject;

public bool xAxis;

public bool yAxis;

public bool xAxisAuto;

public bool yAxisAuto;

[Range(0f, 20f)]
public float lightIntensity = 5f;

public Color lightColour = Color.white;

public Color backgroundColour = Color.clear;

[Range(1f, 10f)]
public float objectSize = 4f;

[Range(0.5f, 20f)]
public float autoSpeed = 1f;

[Range(1f, 20f)]
public float dragSpeed = 10f;

[Range(0f, 100f)]
public float centerModel;

[Range(-1000f, 1000f)]
public float centerCamera;

[Range(0.1f, 10f)]
public float outlineWidth;

public Color outlineColour;

private RenderTexture renderTexture;

private RectTransform rt;

private RawImage img;

private Camera targetCamera;

private GameObject imageObject;

public Vector3 axis = new Vector3(0f, 1f, 0f);

private float Rotation;

private Light cameraLight;

private Vector3 speed = Vector3.zero;

private Vector3 averageSpeed = Vector3.zero;

private Vector2 lastMousePosition = Vector2.zero;

public float RotationSpeed = 10f;

public bool RotateX = true;

public bool InvertX;

public bool RotateY = true;

public bool InvertY;

public bool invertZ;

public int invert;

private int _xMultiplier
{ 
get
{ 
if (!this.InvertX)
{ 
return 1;
}
return -1;
}
}

private int _yMultiplier
{ 
get
{ 
if (!this.InvertY)
{ 
return 1;
}
return -1;
}
}

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.invert = (this.invertZ ? -1 : 1);
if (this.renderTexture == null)
{ 
this.rt = (RectTransform)this.targetObject.transform;
this.renderTexture = new RenderTexture((int)this.rt.rect.width * 2, (int)this.rt.rect.height * 2, 24, RenderTextureFormat.ARGB32);
this.renderTexture.Create();
}
if (this.img == null)
{ 
this.img = this.targetObject.gameObject.GetComponent<RawImage>();
this.img.texture = this.renderTexture;
}
if (this.imageObject == null)
{ 
this.imageObject = UnityEngine.Object.Instantiate<GameObject>(this.targetModel.GetValue(target), this.rt.position, Quaternion.identity);
this.imageObject.transform.localScale = new Vector3(this.objectSize, this.objectSize, this.objectSize);
this.imageObject.name = "UICloneObject";
}
if (this.targetCamera == null)
{ 
GameObject gameObject = new GameObject();
this.targetCamera = gameObject.AddComponent<Camera>();
this.targetCamera.enabled = true;
this.targetCamera.allowHDR = true;
this.targetCamera.targetTexture = this.renderTexture;
this.targetCamera.orthographic = true;
this.targetCamera.name = "UI3DCamera";
this.targetCamera.clearFlags = CameraClearFlags.Color;
this.targetCamera.backgroundColor = this.backgroundColour;
this.targetCamera.gameObject.layer = ActionDisplayCanvasModel.layermask_to_layer(this.objectImageLayer.value);
this.targetCamera.cullingMask = this.objectImageLayer.value;
this.targetCamera.transform.position = new Vector3(this.imageObject.transform.position.x, this.imageObject.transform.position.y + this.centerCamera, (float)this.invert);
}
if (this.cameraLight == null)
{ 
this.cameraLight = this.targetCamera.gameObject.AddComponent<Light>();
this.cameraLight.gameObject.layer = ActionDisplayCanvasModel.layermask_to_layer(this.objectImageLayer.value);
this.cameraLight.cullingMask = this.objectImageLayer.value;
this.cameraLight.type = this.objectLight;
this.cameraLight.intensity = this.lightIntensity / 10f;
this.cameraLight.range = 200f;
this.cameraLight.color = this.lightColour;
this.cameraLight.bounceIntensity = 1f;
}
Vector3 a = this.imageObject.transform.position - this.targetCamera.transform.position;
float d = 1f;
this.imageObject.transform.position = this.targetCamera.transform.position + a * d;
this.imageObject.transform.position = new Vector3(this.imageObject.transform.position.x, this.imageObject.transform.position.y, this.imageObject.transform.position.z - this.centerModel);
this.imageObject.transform.LookAt(this.targetCamera.transform.position + this.targetCamera.transform.rotation * Vector3.forward, this.targetCamera.transform.rotation * Vector3.up);
Vector3 worldPosition = this.imageObject.transform.position + Vector3.up * 5f;
this.cameraLight.transform.LookAt(worldPosition);
this.targetCamera.transform.LookAt(worldPosition);
this.targetCamera.Render();
if (!this.targetObject.gameObject.GetComponent<Outline>())
{ 
this.targetObject.gameObject.AddComponent<Outline>();
}
if (!this.targetObject.gameObject.GetComponent<MouseOver>())
{ 
this.targetObject.gameObject.AddComponent<MouseOver>();
}
this.targetObject.gameObject.GetComponent<Outline>().effectDistance = new Vector2(this.outlineWidth, -this.outlineWidth);
this.targetObject.gameObject.GetComponent<Outline>().effectColor = this.outlineColour;
this.targetObject.gameObject.GetComponent<Outline>().enabled = false;
if (this.outlineObject)
{ 
this.targetObject.gameObject.GetComponent<MouseOver>().outlineObject = true;
}
else
{ 
this.targetObject.gameObject.GetComponent<MouseOver>().outlineObject = false;
}
return true;
gameObject
a
d
worldPosition
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

public static int layermask_to_layer(LayerMask layerMask)
{ 
int num = 0;
int i = layerMask.value;
while (i > 0)
{ 
i >>= 1;
num++;
}
return num - 1;
num
i
}

private void Update()
{ 
if (this.imageObject != null && this.spinObject)
{ 
float yAngle = 0f;
float xAngle = 0f;
if (this.xAxisAuto)
{ 
yAngle = this.autoSpeed;
}
if (this.yAxisAuto)
{ 
xAngle = this.autoSpeed;
}
if (this.imageObject != null)
{ 
this.imageObject.transform.Rotate(xAngle, yAngle, 0f);
}
}
if (this.imageObject != null && this.dragObject && this.targetObject.gameObject.GetComponent<MouseOver>().overObject)
{ 
if (this.lastMousePosition == Vector2.zero)
{ 
this.lastMousePosition = Input.mousePosition;
}
if (Input.GetMouseButton(0))
{ 
Vector2 vector = (Input.mousePosition - this.lastMousePosition) * 100f;
vector.Set(vector.x / (float)Screen.width, vector.y / (float)Screen.height);
this.speed = new Vector3(-vector.x * (float)this._xMultiplier, vector.y * (float)this._yMultiplier, 0f);
}
if (this.speed != Vector3.zero)
{ 
if (this.xAxis)
{ 
this.imageObject.transform.Rotate(0f, this.speed.x * this.dragSpeed, 0f);
}
if (this.yAxis)
{ 
this.imageObject.transform.Rotate(this.speed.y * this.dragSpeed, 0f, 0f);
}
}
this.lastMousePosition = Input.mousePosition;
}
yAngle
xAngle
vector
}
}
}
