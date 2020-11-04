using GameCreator.Core;
using System;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionHideTMPTooltip : IAction
{ 
public Actions actions;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
ActionShowTMPTooltip[] components = this.actions.gameObject.GetComponents<ActionShowTMPTooltip>();
for (int i = 0; i < components.Length; i++)
{ 
components[i].Stop();
}
return true;
components
i
}
}
}
