using GameCreator.Core;
using System;
using System.Collections;
using UnityEngine;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionDisplaySysInfo : IAction
{ 
public enum INFOPOSITION
{ 
TopRight,
TopLeft,
BottomLeft,
BottomRight
}

public enum INFOTYPE
{ 
FPSAndMEM,
HWConfig
}

public GameObject infoPanel;

public SysInfo infoSwitch;

public GameObject fpsPanel;

public GameObject hwPanel;

public ActionDisplaySysInfo.INFOPOSITION infoPosition = ActionDisplaySysInfo.INFOPOSITION.TopLeft;

public ActionDisplaySysInfo.INFOTYPE infoType;

private float swidth;

private float sheight;

private float soffsetx;

private float soffsety;

private RectTransform s_RectTransform;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.fpsPanel = this.infoPanel.transform.GetChild(0).gameObject;
this.hwPanel = this.infoPanel.transform.GetChild(1).gameObject;
this.infoSwitch = this.infoPanel.GetComponentInChildren<SysInfo>();
this.s_RectTransform = this.infoPanel.GetComponent<RectTransform>();
this.s_RectTransform.localScale += new Vector3(0f, 0f, 0f);
this.swidth = this.s_RectTransform.rect.width;
this.sheight = this.s_RectTransform.rect.height;
this.soffsetx = this.s_RectTransform.position.x;
this.soffsety = this.s_RectTransform.position.y;
switch (this.infoPosition)
{ 
case ActionDisplaySysInfo.INFOPOSITION.TopRight: 
this.s_RectTransform.anchoredPosition = new Vector3((float)Screen.width - (this.swidth + this.soffsetx), (float)Screen.height - (this.sheight + this.soffsety));
break;
case ActionDisplaySysInfo.INFOPOSITION.TopLeft: 
this.s_RectTransform.anchoredPosition = new Vector3(this.soffsetx, (float)Screen.height - (this.sheight + this.soffsety));
break;
case ActionDisplaySysInfo.INFOPOSITION.BottomLeft: 
this.s_RectTransform.anchoredPosition = new Vector3(this.soffsetx, this.soffsety);
break;
case ActionDisplaySysInfo.INFOPOSITION.BottomRight: 
this.s_RectTransform.anchoredPosition = new Vector3((float)Screen.width - (this.swidth + this.soffsetx), this.soffsety);
break;
 }
ActionDisplaySysInfo.INFOTYPE iNFOTYPE = this.infoType;
if (iNFOTYPE != ActionDisplaySysInfo.INFOTYPE.FPSAndMEM)
{ 
if (iNFOTYPE == ActionDisplaySysInfo.INFOTYPE.HWConfig)
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
