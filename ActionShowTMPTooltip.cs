using GameCreator.Core;
using GameCreator.Localization;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
[AddComponentMenu("")]
public class ActionShowTMPTooltip : IAction
{ 
public GameObject tooltipPanel;

public Color panelcolor = Color.black;

public AudioClip audioClip;

[LocStringNoPostProcess]
public LocString message = new LocString();

public Color textcolor = Color.white;

public float time = 2f;

public TargetGameObject target = new TargetGameObject(TargetGameObject.Target.GameObject);

public Vector3 offset = new Vector3(-60f, 60f, 0f);

private Image tooltippanel;

private TextMeshProUGUI tooltipText;

public TMP_FontAsset font;

[IteratorStateMachine(typeof(ActionShowTMPTooltip.<Execute>d__11))]
public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
{ 
while (true)
{ 
int num;
switch (num)
{ 
case 0:
{ 
if (this.audioClip != null)
{ 
AudioMixerGroup voiceAudioMixer = DatabaseGeneral.Load().voiceAudioMixer;
Singleton<AudioManager>.Instance.PlayVoice(this.audioClip, 0f, 1f, voiceAudioMixer);
}
this.tooltippanel = this.tooltipPanel.GetComponent<Image>();
this.tooltipText = this.tooltipPanel.GetComponentInChildren<TextMeshProUGUI>();
if (this.tooltippanel != null)
{ 
this.tooltippanel.color = this.panelcolor;
}
if (this.tooltipText != null)
{ 
this.tooltipText.text = this.message.GetText();
this.tooltipText.color = this.textcolor;
if (this.font != null)
{ 
this.tooltipText.font = this.font;
}
}
this.tooltipPanel.transform.position = new Vector3(target.transform.position.x + this.offset.x, target.transform.position.y + this.offset.y, target.transform.position.z + this.offset.z);
this.tooltipPanel.SetActive(true);
float waitTime = Time.unscaledTime + this.time;
WaitUntil waitUntil = new WaitUntil(() => Time.unscaledTime > waitTime);
yield return waitUntil;
continue;
}
case 1: 
if (this.audioClip != null)
{ 
Singleton<AudioManager>.Instance.StopVoice(this.audioClip, 0f);
}
this.tooltipPanel.SetActive(false);
yield return 0;
continue;
case 2: 
goto IL_1F9;
 }
break;
}
yield break;
IL_1F9:
yield break;
num
arg_17B_0
voiceAudioMixer
waitUntil
}
}
}
