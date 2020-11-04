using GameCreator.Core;
using System;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionDeleteAllProfiles : IAction
{ 
public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
SavesData.Profiles arg_0F_0 = Singleton<SaveLoadManager>.Instance.savesData.profiles;
for (int i = -99; i < 99; i++)
{ 
Debug.Log("Deleting Profile " + i);
Singleton<SaveLoadManager>.Instance.DeleteProfile(i);
}
return true;
arg_0F_0
i
}
}
}
