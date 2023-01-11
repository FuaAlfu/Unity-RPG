using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.1.11
/// </summary>

namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(1,99)]
        [SerializeField]
        int startinglevel = 1;

        [SerializeField]
        CharacterClass characterClass;
    }
}
