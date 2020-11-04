using GameCreator.Variables;
using System;
using UnityEngine;


namespace PivecLabs.Tools
{ 
public class CommandGlobals : ConsoleInput
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

public static CommandGlobals CreateCommand()
{ 
return new CommandGlobals();
}

public CommandGlobals()
{ 
this.Command = "globals";
this.Description = string.Format("{0}{1}", this.Command.PadRight(15), "Displays all global variables");
base.AddCommandToConsole();
}

public override void RunCommandwithPar(string name)
{ 
this.RunCommand();
}

public override void RunCommandwithPars(string name, string value)
{ 
this.RunCommand();
}

public override void RunCommand()
{ 
GlobalVariables globalVariables = DatabaseVariables.Load().GetGlobalVariables();
if (globalVariables != null)
{ 
for (int i = 0; i < globalVariables.references.Length; i++)
{ 
int expr_30 = globalVariables.references[i].variable.type;
if (expr_30 == 1)
{ 
this.varType = "String";
}
if (expr_30 == 3)
{ 
this.varType = "Bool";
}
if (expr_30 == 2)
{ 
this.varType = "String";
}
if (expr_30 == 3)
{ 
this.varType = "Number";
}
if (expr_30 == 4)
{ 
this.varType = "Color";
}
if (expr_30 == 9)
{ 
this.varType = "GameObject";
}
if (expr_30 == 8)
{ 
this.varType = "Sprite";
}
if (expr_30 == 7)
{ 
this.varType = "Texture2D";
}
if (expr_30 == 5)
{ 
this.varType = "Vector2";
}
if (expr_30 == 6)
{ 
this.varType = "Vector3";
}
this.varName = string.Format("{0}", globalVariables.references[i].variable.name);
this.varValue = VariablesManager.GetGlobal(globalVariables.references[i].variable.name).ToString();
Debug.Log(string.Format("Name: {0}Type: {1}Value: {2}", this.varName.PadRight(25), this.varType.PadRight(10), this.varValue.PadRight(20)));
}
return;
}
Debug.Log("No Global Variables Defined");
globalVariables
i
expr_30
}
}
}
