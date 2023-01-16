using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.1.16
/// </summary>

[CreateAssetMenu(menuName ="status/new progression",fileName ="progress",order = 1)]
public class Progression: ScriptableObject
{
    [SerializeField]
    ProgressionCharacterClass characterClass;

    [System.Serializable]
    class ProgressionCharacterClass
    {
        int value = 1;
        string name = "value";
    }
}
