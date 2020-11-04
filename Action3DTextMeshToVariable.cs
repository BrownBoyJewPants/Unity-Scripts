using GameCreator.Core;
using GameCreator.Variables;
using System;
using TMPro;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshToVariable : IAction
{ 
[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.String
})]
public VariableProperty targetVariable = new VariableProperty(Variable.VarType.GlobalVariable);

public TextMeshPro textdata;

public string content = "{0}";

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
if (this.textdata != null)
{ 
this.targetVariable.Set(this.textdata.text.ToString(), target);
}
return true;
}
}
}
