using GameCreator.Core;
using System;
using UnityEngine;
using UnityEngine.Events;


namespace PivecLabs.Tools
{ 
public class CommandEvents : ConsoleInput
{ 
private int count;

private int target;

private string method;

public UnityEvent onList = new UnityEvent();

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

public static CommandEvents CreateCommand()
{ 
return new CommandEvents();
}

public CommandEvents()
{ 
this.Command = "events";
this.Description = string.Format("{0}{1}", this.Command.PadRight(15), "Lists all Game Creator Events");
base.AddCommandToConsole();
}

public override void RunCommand()
{ 
string[] subscribedKeys = Singleton<EventDispatchManager>.Instance.GetSubscribedKeys();
Debug.Log("Events in Total = " + subscribedKeys.Length);
string[] array = subscribedKeys;
for (int i = 0; i < array.Length; i++)
{ 
string str = array[i];
Debug.Log("source = " + str);
}
subscribedKeys
array
i
str
}

public override void RunCommandwithPar(string name)
{ 
this.RunCommand();
}

public override void RunCommandwithPars(string name, string value)
{ 
this.RunCommand();
}
}
}
