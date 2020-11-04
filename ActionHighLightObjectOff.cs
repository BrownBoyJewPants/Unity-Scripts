using GameCreator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionHighLightObjectOff : IAction
{ 
[CompilerGenerated]
[Serializable]
private sealed class <>c
{ 
public static readonly ActionHighLightObjectOff.<>c <>9 = new ActionHighLightObjectOff.<>c();

public static Predicate<Material> <>9__2_0;

public static Predicate<Material> <>9__2_1;

internal bool <InstantExecute>b__2_0(Material x)
{ 
return x.name == "FillObject (Instance)";
}

internal bool <InstantExecute>b__2_1(Material x)
{ 
return x.name == "MaskObject (Instance)";
}
}

public GameObject TargetObject;

private Renderer[] renderers;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.renderers = this.TargetObject.GetComponentsInChildren<Renderer>();
Renderer[] array = this.renderers;
for (int i = 0; i < array.Length; i++)
{ 
Renderer expr_1F = array[i];
List<Material> list = expr_1F.sharedMaterials.ToList<Material>();
List<Material> arg_4B_0 = list;
Predicate<Material> arg_4B_1;
if ((arg_4B_1 = ActionHighLightObjectOff.<>c.<>9__2_0) == null)
{ 
arg_4B_1 = (ActionHighLightObjectOff.<>c.<>9__2_0 = new Predicate<Material>(ActionHighLightObjectOff.<>c.<>9.<InstantExecute>b__2_0));
}
arg_4B_0.RemoveAll(arg_4B_1);
List<Material> arg_71_0 = list;
Predicate<Material> arg_71_1;
if ((arg_71_1 = ActionHighLightObjectOff.<>c.<>9__2_1) == null)
{ 
arg_71_1 = (ActionHighLightObjectOff.<>c.<>9__2_1 = new Predicate<Material>(ActionHighLightObjectOff.<>c.<>9.<InstantExecute>b__2_1));
}
arg_71_0.RemoveAll(arg_71_1);
expr_1F.materials = list.ToArray();
}
return true;
array
i
expr_1F
list
arg_4B_0
arg_4B_1
arg_71_0
arg_71_1
}
}
}
