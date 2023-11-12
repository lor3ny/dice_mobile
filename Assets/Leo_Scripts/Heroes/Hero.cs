using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero 
{
    public int Health;
    public Sprite Sprite;
    public Ability[] CurrentAbilities;
    public List<Ability> Abilities;
    public HeroType HeroType;
}
public enum HeroType
{
    closeRange,
    longRange,
    support,
    mage
}
