using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace PivecLabs.Tools
{ 
[AddComponentMenu("")]
public class ActionToggleConsole : IAction
{ 
public bool showConsole;

public GameObject consoleManager;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
if (this.showConsole)
{ 
this.consoleManager.GetComponent<InGameConsole>().showConsole = true;
}
else if (!this.showConsole)
{ 
this.consoleManager.GetComponent<InGameConsole>().showConsole = false;
}
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
