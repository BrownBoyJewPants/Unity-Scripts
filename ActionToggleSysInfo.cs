using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionToggleSysInfo : IAction
{ 
public enum INFOTYPE
{ 
FPSAndMEM,
HWConfig
}

public GameObject infoPanel;

public SysInfo infoSwitch;

public GameObject fpsPanel;

public GameObject hwPanel;

public ActionToggleSysInfo.INFOTYPE infoType;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.fpsPanel = this.infoPanel.transform.GetChild(0).gameObject;
this.hwPanel = this.infoPanel.transform.GetChild(1).gameObject;
this.infoSwitch = this.infoPanel.GetComponentInChildren<SysInfo>();
ActionToggleSysInfo.INFOTYPE iNFOTYPE = this.infoType;
if (iNFOTYPE != ActionToggleSysInfo.INFOTYPE.FPSAndMEM)
{ 
if (iNFOTYPE == ActionToggleSysInfo.INFOTYPE.HWConfig)
{ 
this.infoSwitch.fpsinfo = false;
this.fpsPanel.SetActive(false);
this.hwPanel.SetActive(true);
}
}
else
{ 
this.infoSwitch.fpsinfo = true;
this.hwPanel.SetActive(false);
this.fpsPanel.SetActive(true);
}
return true;
iNFOTYPE
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}
}
}
