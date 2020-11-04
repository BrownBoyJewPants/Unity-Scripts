using GameCreator.Core;
using System;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionHideTooltip : IAction
{ 
public Actions actions;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
ActionShowTooltip[] components = this.actions.gameObject.GetComponents<ActionShowTooltip>();
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
