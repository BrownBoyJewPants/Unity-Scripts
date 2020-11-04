using GameCreator.Characters;
using GameCreator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionAddMapMarkers : IAction
{ 
[Serializable]
public class Marker
{ 
public string Tag;

public Texture2D Image;
}

public GameObject mapPanel;

public GameObject rawImage;

[SerializeField]
public List<ActionAddMapMarkers.Marker> MapMarkers = new List<ActionAddMapMarkers.Marker>();

public Material frontPlane;

[Range(0f, 5f)]
public float markerSize = 0.2f;

private Vector3 markers;

private PlayerCharacter player;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
for (int i = 0; i < this.MapMarkers.Capacity; i++)
{ 
GameObject[] array = GameObject.FindGameObjectsWithTag(this.MapMarkers[i].Tag);
if (array != null)
{ 
for (int j = 0; j < array.Length; j++)
{ 
GameObject expr_31 = GameObject.CreatePrimitive(PrimitiveType.Plane);
expr_31.name = "MapMarkerImage";
expr_31.transform.localScale = new Vector3(this.markerSize, this.markerSize, this.markerSize);
expr_31.transform.parent = array[j].transform;
expr_31.transform.position = array[j].transform.position + new Vector3(0f, 10f, 0f);
Material material = new Material(Shader.Find("Unlit/Transparent Cutout"));
material.mainTexture = this.MapMarkers[i].Image;
expr_31.GetComponent<Renderer>().material = material;
}
}
}
return true;
i
array
j
expr_31
material
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
