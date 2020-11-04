using GameCreator.Core;
using GameCreator.Variables;
using System;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionCurrentProfilefromVar : IAction
{ 
public NumberProperty profile = new NumberProperty(0f);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
int currentProfile = (int)this.profile.GetValue(target);
Singleton<SaveLoadManager>.Instance.SetCurrentProfile(currentProfile);
return true;
currentProfile
}
}
}
