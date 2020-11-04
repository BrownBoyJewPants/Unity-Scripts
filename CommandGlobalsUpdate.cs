using GameCreator.Variables;
using System;
using UnityEngine;


namespace PivecLabs.Tools
{ 
public class CommandGlobalsUpdate : ConsoleInput
{ 
private string varType;

private string varName;

private string varValue;

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

public static CommandGlobalsUpdate CreateCommand()
{ 
return new CommandGlobalsUpdate();
}

public CommandGlobalsUpdate()
{ 
this.Command = "globalsU";
this.Description = string.Format("{0}{1}", this.Command.PadRight(15), "Updates value (string,bool,number) of a global variable");
base.AddCommandToConsole();
}

public override void RunCommand()
{ 
Debug.Log("Parameter Required");
}

public override void RunCommandwithPar(string name)
{ 
Debug.Log("Two Parameters Required");
}

public override void RunCommandwithPars(string name, string value)
{ 
if (VariablesManager.ExistsGlobal(name))
{ 
switch (VariablesManager.GetGlobalType(name, false))
{ 
case Variable.DataType.String: 
VariablesManager.SetGlobal(name, value);
break;
case Variable.DataType.Number: 
VariablesManager.SetGlobal(name, float.Parse(value));
break;
case Variable.DataType.Bool: 
VariablesManager.SetGlobal(name, Convert.ToBoolean(value));
break;
 }
this.varName = name;
this.varValue = VariablesManager.GetGlobal(name).ToString();
Debug.Log(string.Format("Name: {0}Value: {1}", this.varName.PadRight(25), this.varValue.PadRight(20)));
return;
}
Debug.Log("Variable name incorrect");
}
}
}
