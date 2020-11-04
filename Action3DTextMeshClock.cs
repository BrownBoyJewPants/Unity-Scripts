using GameCreator.Core;
using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class Action3DTextMeshClock : IAction
{ 
public GameObject textObject;

public bool seconds;

private TextMeshPro textdata;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
base.CancelInvoke("systemTime");
if (this.seconds)
{ 
base.InvokeRepeating("systemTime", 0f, 1f);
}
else
{ 
base.InvokeRepeating("systemTime", 0f, 60f);
}
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void systemTime()
{ 
DateTime now = DateTime.Now;
this.textdata = this.textObject.GetComponent<TextMeshPro>();
if (this.seconds)
{ 
this.textdata.text = now.ToString("HH:mm:ss");
return;
}
this.textdata.text = now.ToString("HH:mm");
now
}

public void StopRepeating()
{ 
base.CancelInvoke("systemTime");
}
}
}
