using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : ScriptableObject
{
    public Effect Effect;
    public Target Target = Target.selectedTarget;
}
public enum Effect
{
    physicalDmg,
    magicDmg,
    physicalShield,
    magicShield,
    poison,
    antidote,
    heal,
    regen
}
public enum Target
{
    selectedTarget,
    self,
    allEnemies,
    allAllies
}
