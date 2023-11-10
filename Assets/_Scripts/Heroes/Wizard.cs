using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Hero
{
    public Wizard()
    {
        HeroType = HeroType.mage;
        Health = 6;
        GetStartingAbilities();
    }
    //TODO: do the same with sprites
    private void GetStartingAbilities()
    {
        Ability ability1 = AbilityHolder.Instance.GetAbility("Manabolt");
        Ability ability2 = AbilityHolder.Instance.GetAbility("Magic Shield");
        Ability ability3 = AbilityHolder.Instance.GetAbility("Poison Dart");
        CurrentAbilities = new Ability[3] { ability1, ability2, ability3 };
        Abilities.Add(ability1);
        Abilities.Add(ability2);
        Abilities.Add(ability3);
    }
}
