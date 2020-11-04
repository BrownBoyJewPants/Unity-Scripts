using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshClockStop : IAction
{ 
public Actions actions;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
Action3DTextMeshClock[] components = this.actions.gameObject.GetComponents<Action3DTextMeshClock>();
for (int i = 0; i < components.Length; i++)
{ 
components[i].StopRepeating();
}
return true;
components
i
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
