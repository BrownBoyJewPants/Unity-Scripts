using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionRemoveMapTMPLabels : IAction
{ 
public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
for (int i = 0; i < array.Length; i++)
{ 
GameObject gameObject = array[i];
if (gameObject.name == "MapMarkerLabel")
{ 
UnityEngine.Object.Destroy(gameObject);
}
}
return true;
array
i
gameObject
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
