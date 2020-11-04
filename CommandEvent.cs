using GameCreator.Core;
using System;
using UnityEngine;


namespace PivecLabs.Tools
{ 
public class CommandEvent : ConsoleInput
{ 
public override string Command
{ 
get;
protected set;
}

public override string Description
{ 
get;
protected set;
}

public static CommandEvent CreateCommand()
{ 
return new CommandEvent();
}

public CommandEvent()
{ 
this.Command = "event";
this.Description = string.Format("{0}{1}", this.Command.PadRight(15), "Dispatches a Game Creator Event");
base.AddCommandToConsole();
}

public override void RunCommandwithPar(string name)
{ 
Singleton<EventDispatchManager>.Instance.Dispatch(name, InGameConsole.Instance.consoleCanvas.gameObject);
Debug.Log(name + " Event Dispatched");
}

public override void RunCommand()
{ 
Debug.Log("Parameter Required");
}

public override void RunCommandwithPars(string name, string value)
{ 
Debug.Log("Single Parameter Required");
}
}
}
