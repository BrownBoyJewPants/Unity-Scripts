using GameCreator.Core;
using System;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionDragObjecttoRotate : IAction
{ 
public GameObject objectToDrag;

public bool allowDragging;

private bool dragging;

private Vector3 speed = Vector3.zero;

private Vector2 lastMousePosition = Vector2.zero;

public bool RotateX = true;

public bool InvertX;

public bool RotateY = true;

public bool InvertY;

public bool invertZ;

public int invert;

[Range(1f, 20f)]
public float dragSpeed = 10f;

public bool xAxis;

public bool yAxis;

[Range(0f, 2f), SerializeField]
public int mouseButton;

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
return true;
}

private void Update()
{ 
if (this.allowDragging)
{ 
RaycastHit raycastHit;
if (Input.GetMouseButtonDown(this.mouseButton) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.transform.name == this.objectToDrag.name)
{ 
this.dragging = true;
}
if (Input.GetMouseButtonUp(this.mouseButton))
{ 
this.dragging = false;
}
if (this.objectToDrag != null && this.dragging)
{ 
if (this.lastMousePosition == Vector2.zero)
{ 
this.lastMousePosition = Input.mousePosition;
}
if (Input.GetMouseButton(this.mouseButton))
{ 
Vector2 vector = (Input.mousePosition - this.lastMousePosition) * 100f;
vector.Set(vector.x / (float)Screen.width, vector.y / (float)Screen.height);
this.speed = new Vector3(-vector.x * (float)this._xMultiplier, vector.y * (float)this._yMultiplier, 0f);
}
if (this.speed != Vector3.zero)
{ 
if (this.xAxis)
{ 
this.objectToDrag.transform.Rotate(0f, this.speed.x * this.dragSpeed, 0f);
}
if (this.yAxis)
{ 
this.objectToDrag.transform.Rotate(this.speed.y * this.dragSpeed, 0f, 0f);
}
}
this.lastMousePosition = Input.mousePosition;
}
}
raycastHit
vector
}
}
}
