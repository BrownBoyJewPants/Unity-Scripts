using GameCreator.Core;
using GameCreator.Variables;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionFillImage : IAction
{ 
public enum FILLMETHOD
{ 
Horizontal,
Vertical,
Radial90,
Radial180,
Radial360
}

public enum FILLORIGINH
{ 
Left,
Right
}

public enum FILLORIGINV
{ 
Bottom,
Top
}

public enum FILLORIGINR90
{ 
BottomLeft,
TopLeft,
TopRight,
BottomRight
}

public enum FILLORIGINR
{ 
Bottom,
Left,
Top,
Right
}

public Image imagetofill;

public ActionFillImage.FILLMETHOD fillmethod;

public ActionFillImage.FILLORIGINH filloriginh;

public ActionFillImage.FILLORIGINV filloriginv;

public ActionFillImage.FILLORIGINR90 filloriginr90;

public ActionFillImage.FILLORIGINR filloriginr;

public bool clockwise = true;

public NumberProperty fillamount = new NumberProperty(0f);

private Image image;

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
this.imagetofill.type = Image.Type.Filled;
switch (this.fillmethod)
{ 
case ActionFillImage.FILLMETHOD.Horizontal: 
this.imagetofill.fillMethod = Image.FillMethod.Horizontal;
this.FillOriginH();
break;
case ActionFillImage.FILLMETHOD.Vertical: 
this.imagetofill.fillMethod = Image.FillMethod.Vertical;
this.FillOriginV();
break;
case ActionFillImage.FILLMETHOD.Radial90: 
this.imagetofill.fillMethod = Image.FillMethod.Radial90;
this.FillOriginR90();
this.imagetofill.fillClockwise = this.clockwise;
break;
case ActionFillImage.FILLMETHOD.Radial180: 
this.imagetofill.fillMethod = Image.FillMethod.Radial180;
this.FillOriginR180();
this.imagetofill.fillClockwise = this.clockwise;
break;
case ActionFillImage.FILLMETHOD.Radial360: 
this.imagetofill.fillMethod = Image.FillMethod.Radial360;
this.FillOriginR360();
this.imagetofill.fillClockwise = this.clockwise;
break;
 }
this.imagetofill.fillAmount = this.fillamount.GetValue(target);
return true;
}

public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
return base.Execute(target, actions, index);
}

private void FillOriginH()
{ 
ActionFillImage.FILLORIGINH fILLORIGINH = this.filloriginh;
if (fILLORIGINH == ActionFillImage.FILLORIGINH.Left)
{ 
this.imagetofill.fillOrigin = 0;
return;
}
if (fILLORIGINH != ActionFillImage.FILLORIGINH.Right)
{ 
return;
}
this.imagetofill.fillOrigin = 1;
fILLORIGINH
}

private void FillOriginV()
{ 
ActionFillImage.FILLORIGINV fILLORIGINV = this.filloriginv;
if (fILLORIGINV == ActionFillImage.FILLORIGINV.Bottom)
{ 
this.imagetofill.fillOrigin = 0;
return;
}
if (fILLORIGINV != ActionFillImage.FILLORIGINV.Top)
{ 
return;
}
this.imagetofill.fillOrigin = 1;
fILLORIGINV
}

private void FillOriginR90()
{ 
switch (this.filloriginr90)
{ 
case ActionFillImage.FILLORIGINR90.BottomLeft: 
this.imagetofill.fillOrigin = 0;
return;
case ActionFillImage.FILLORIGINR90.TopLeft: 
this.imagetofill.fillOrigin = 1;
return;
case ActionFillImage.FILLORIGINR90.TopRight: 
this.imagetofill.fillOrigin = 2;
return;
case ActionFillImage.FILLORIGINR90.BottomRight: 
this.imagetofill.fillOrigin = 3;
return;
default: 
return;
 }
}

private void FillOriginR180()
{ 
switch (this.filloriginr)
{ 
case ActionFillImage.FILLORIGINR.Bottom: 
this.imagetofill.fillOrigin = 0;
return;
case ActionFillImage.FILLORIGINR.Left: 
this.imagetofill.fillOrigin = 1;
return;
case ActionFillImage.FILLORIGINR.Top: 
this.imagetofill.fillOrigin = 2;
return;
case ActionFillImage.FILLORIGINR.Right: 
this.imagetofill.fillOrigin = 3;
return;
default: 
return;
 }
}

private void FillOriginR360()
{ 
switch (this.filloriginr)
{ 
case ActionFillImage.FILLORIGINR.Bottom: 
this.imagetofill.fillOrigin = 0;
return;
case ActionFillImage.FILLORIGINR.Left: 
this.imagetofill.fillOrigin = 3;
return;
case ActionFillImage.FILLORIGINR.Top: 
this.imagetofill.fillOrigin = 2;
return;
case ActionFillImage.FILLORIGINR.Right: 
this.imagetofill.fillOrigin = 1;
return;
default: 
return;
 }
}
}
}
