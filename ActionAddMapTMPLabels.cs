using GameCreator.Characters;
using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionAddMapTMPLabels : IAction
{ 
[Serializable]
public class Marker
{ 
public string Tag;

public string text;
}

public GameObject mapPanel;

public GameObject rawImage;

[Range(1f, 60f)]
public float cameraSize = 20f;

[Range(1f, 60f)]
public float cameraDistance = 20f;

public ColorProperty outlinecolor = new ColorProperty(Color.black);

public ColorProperty textcolor = new ColorProperty(Color.white);

[SerializeField]
public List<ActionAddMapTMPLabels.Marker> MapMarkers = new List<ActionAddMapTMPLabels.Marker>();

public Material frontPlane;

[Range(0f, 2f)]
public float markerSize = 0.4f;

private Vector3 markers;

private TextMeshPro textMeshPro;

private PlayerCharacter player;

public int Layer;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
for (int i = 0; i < this.MapMarkers.Capacity; i++)
{ 
GameObject[] array = GameObject.FindGameObjectsWithTag(this.MapMarkers[i].Tag);
if (array != null)
{ 
for (int j = 0; j < array.Length; j++)
{ 
GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
gameObject.name = "MapMarkerLabel";
gameObject.layer = this.Layer;
gameObject.transform.localScale = new Vector3(this.markerSize, this.markerSize, this.markerSize);
gameObject.transform.parent = array[j].transform;
gameObject.transform.position = array[j].transform.position + new Vector3(0f, 10f, 0f);
gameObject.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
new Material(Shader.Find("TextMeshPro/Bitmap"));
this.textMeshPro = gameObject.AddComponent<TextMeshPro>();
this.textMeshPro.fontSize = 30f;
this.textMeshPro.outlineColor = this.outlinecolor.GetValue(target);
this.textMeshPro.outlineWidth = 0.2f;
this.textMeshPro.color = this.textcolor.GetValue(target);
this.textMeshPro.enableAutoSizing = true;
this.textMeshPro.alignment = TextAlignmentOptions.Center;
this.textMeshPro.text = this.MapMarkers[i].text;
}
}
}
return true;
i
array
j
gameObject
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
