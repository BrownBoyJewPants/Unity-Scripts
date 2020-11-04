using GameCreator.Core;
using GameCreator.Variables;
using System;
using TMPro;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionTMPUIVariableToText : IAction
{ 
[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.String
})]
public VariableProperty targetVariable = new VariableProperty(Variable.VarType.GlobalVariable);

public TMP_Text tmptext;

public string content = "{0}";

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
if (this.tmptext != null)
{ 
TMP_Text arg_36_0 = this.tmptext;
string arg_31_0 = this.content;
object[] args = new string[]
{ 
this.targetVariable.ToStringValue(target)
};
arg_36_0.text = string.Format(arg_31_0, args);
}
return true;
arg_36_0
arg_31_0
args
}
}
}
