using GameCreator.Core;
using System;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionDestroyUIClones : IAction
{ 
public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
for (int i = 0; i < array.Length; i++)
{ 
GameObject gameObject = array[i];
if (gameObject.name == "UICloneObject" || gameObject.name == "UI3DCamera")
{ 
UnityEngine.Object.Destroy(gameObject, 0f);
}
}
return true;
array
i
gameObject
}
}
}
