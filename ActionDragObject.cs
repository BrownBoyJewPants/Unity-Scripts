using GameCreator.Core;
using System;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionDragObject : IAction
{ 
public GameObject objectToDrag;

public bool allowDragging;

public bool restrictDragging;

public bool xAxis;

public bool yAxis;

public bool zAxis;

private bool dragging;

private Rigidbody r;

private Vector3 speed = Vector3.zero;

private Vector2 lastMousePosition = Vector2.zero;

private Vector3 mOffset;

private float mZCoord;

[Range(0f, 2f), SerializeField]
public int mouseButton;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
return true;
}

private Vector3 GetMouseAsWorldPoint()
{ 
Vector3 mousePosition = Input.mousePosition;
mousePosition.z = this.mZCoord;
return Camera.main.ScreenToWorldPoint(mousePosition);
mousePosition
}

private void Update()
{ 
if (this.allowDragging)
{ 
RaycastHit raycastHit;
if (Input.GetMouseButtonDown(this.mouseButton) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.transform.name == this.objectToDrag.name)
{ 
this.dragging = true;
this.mZCoord = Camera.main.WorldToScreenPoint(this.objectToDrag.transform.position).z;
this.mOffset = this.objectToDrag.transform.position - this.GetMouseAsWorldPoint();
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
}
if (this.restrictDragging)
{ 
if (this.xAxis)
{ 
Vector3 vector2 = this.GetMouseAsWorldPoint() + this.mOffset;
this.objectToDrag.transform.position = new Vector3(this.objectToDrag.transform.position.x, vector2.y, this.objectToDrag.transform.position.z);
}
if (this.yAxis)
{ 
Vector3 vector3 = this.GetMouseAsWorldPoint() + this.mOffset;
this.objectToDrag.transform.position = new Vector3(vector3.x, this.objectToDrag.transform.position.y, this.objectToDrag.transform.position.z);
}
if (this.zAxis)
{ 
Vector3 vector4 = this.GetMouseAsWorldPoint() + this.mOffset;
this.objectToDrag.transform.position = new Vector3(this.objectToDrag.transform.position.x, this.objectToDrag.transform.position.y, vector4.z);
}
}
else
{ 
this.objectToDrag.transform.position = this.GetMouseAsWorldPoint() + this.mOffset;
}
this.lastMousePosition = Input.mousePosition;
}
}
raycastHit
vector
vector2
vector3
vector4
}
}
}
