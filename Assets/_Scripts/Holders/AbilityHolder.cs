using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public static AbilityHolder Instance;

    [SerializeField]
    private List<Ability> abilities;

    private Dictionary<string, Ability> abilitiesDictionary;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        abilitiesDictionary = abilities.ToDictionary(x => x.Name);
    }
    public Ability GetAbility(string abilityName)
    {
        if (string.IsNullOrEmpty(abilityName))
        {
            throw new ArgumentException("Ability name cannot be null or empty.", nameof(abilityName));
        }

        if (abilitiesDictionary.TryGetValue(abilityName, out Ability ability))
        {
            return ability;
        }
        else
        {
            throw new KeyNotFoundException($"No ability found with the name '{abilityName}'.");
        }
    }
}
