using GameCreator.Characters;
using GameCreator.Core;
using System;
using UnityEngine;


namespace PivecLabs.ActionPack
{ 
[AddComponentMenu("")]
public class ActionDisableNavMesh : IAction
{ 
public bool navmesh;

public TargetCharacter character = new TargetCharacter(TargetCharacter.Target.Player);

public override bool InstantExecute(GameObject target, IAction[] actions, int index)
{ 
Character character = this.character.GetCharacter(target);
if (character == null)
{ 
return true;
}
CharacterLocomotion characterLocomotion = character.characterLocomotion;
if (this.navmesh)
{ 
characterLocomotion.canUseNavigationMesh = true;
}
else
{ 
characterLocomotion.canUseNavigationMesh = false;
}
return true;
character
characterLocomotion
}
}
}
