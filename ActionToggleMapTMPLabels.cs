using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionToggleMapTMPLabels : IAction
{ 
public bool showing;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
for (int i = 0; i < array.Length; i++)
{ 
GameObject gameObject = array[i];
if (gameObject.name == "MapMarkerLabel")
{ 
gameObject.SetActive(this.showing);
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
