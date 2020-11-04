using System;
using UnityEngine;


namespace PivecLabs.Tools
{ 
public class CommandDecreaseQuality : ConsoleInput
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

public static CommandDecreaseQuality CreateCommand()
{ 
return new CommandDecreaseQuality();
}

public CommandDecreaseQuality()
{ 
this.Command = "quality-";
this.Description = string.Format("{0}{1}", this.Command.PadRight(15), "Decrease Quality Level with/without expensive changes (true/false) ");
base.AddCommandToConsole();
}

public override void RunCommand()
{ 
Debug.Log("Parameter Required - true or false");
}

public override void RunCommandwithPar(string name)
{ 
QualitySettings.DecreaseLevel(bool.Parse(name));
Debug.Log(string.Format("{0}{1}", "Decrease Quality Level with expensive changes - ", name));
Debug.Log(string.Format("{0}{1}", "Quality Level now = ", QualitySettings.GetQualityLevel()));
}

public override void RunCommandwithPars(string name, string value)
{ 
Debug.Log("Only one Parameter Required  - true or false");
}
}
}
