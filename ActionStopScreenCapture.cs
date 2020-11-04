using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.Tools
{ 
[AddComponentMenu("")]
public class ActionStopScreenCapture : IAction
{ 
public Actions actions;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
ActionScreenCapture[] components = this.actions.GetComponents<ActionScreenCapture>();
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
