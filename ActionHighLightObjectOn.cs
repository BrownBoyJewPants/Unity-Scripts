using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionHighLightObjectOn : IAction
{ 
public GameObject TargetObject;

private Renderer[] renderers;

private Material highlightMaskMaterial;

private Material highlightFillMaterial;

[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.Color
})]
public VariableProperty HighLightColorVar = new VariableProperty(Variable.VarType.GlobalVariable);

[Range(0f, 6f)]
public float highlightWidth = 1f;

[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.Number
})]
public VariableProperty HighLightWidth = new VariableProperty(Variable.VarType.GlobalVariable);

public bool colourVar;

public bool widthVar;

public Color highlightColour = Color.green;

private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.renderers = this.TargetObject.GetComponentsInChildren<Renderer>();
SkinnedMeshRenderer[] componentsInChildren = this.TargetObject.GetComponentsInChildren<SkinnedMeshRenderer>();
for (int i = 0; i < componentsInChildren.Length; i++)
{ 
SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[i];
if (ActionHighLightObjectOn.registeredMeshes.Add(skinnedMeshRenderer.sharedMesh))
{ 
skinnedMeshRenderer.sharedMesh.uv4 = new Vector2[skinnedMeshRenderer.sharedMesh.vertexCount];
}
}
MeshFilter[] componentsInChildren2 = this.TargetObject.GetComponentsInChildren<MeshFilter>();
for (int i = 0; i < componentsInChildren2.Length; i++)
{ 
MeshFilter meshFilter = componentsInChildren2[i];
meshFilter.sharedMesh.SetUVs(3, new Vector2[meshFilter.sharedMesh.vertexCount]);
}
this.highlightMaskMaterial = UnityEngine.Object.Instantiate<Material>(Resources.Load<Material>("MaskObject"));
this.highlightFillMaterial = UnityEngine.Object.Instantiate<Material>(Resources.Load<Material>("FillObject"));
this.highlightMaskMaterial.name = "MaskObject (Instance)";
this.highlightFillMaterial.name = "FillObject (Instance)";
if (this.colourVar)
{ 
this.highlightColour = (Color)this.HighLightColorVar.Get(target);
}
if (this.widthVar)
{ 
this.highlightWidth = (float)this.HighLightWidth.Get(target);
}
Renderer[] array = this.renderers;
for (int i = 0; i < array.Length; i++)
{ 
Renderer expr_131 = array[i];
List<Material> list = expr_131.sharedMaterials.ToList<Material>();
list.Add(this.highlightMaskMaterial);
list.Add(this.highlightFillMaterial);
expr_131.materials = list.ToArray();
}
this.highlightFillMaterial.SetColor("_HighLightColor", this.highlightColour);
this.highlightMaskMaterial.SetFloat("_ZTest", 8f);
this.highlightFillMaterial.SetFloat("_ZTest", 4f);
this.highlightFillMaterial.SetFloat("_HighLightWidth", this.highlightWidth);
return true;
componentsInChildren
i
skinnedMeshRenderer
componentsInChildren2
meshFilter
array
expr_131
list
}
}
}
