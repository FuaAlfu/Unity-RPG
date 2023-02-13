using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2023.1.16
/// </summary>

namespace RPG.Stats
{
    [CreateAssetMenu(menuName = "status/new progression", fileName = "progress", order = 1)]
    public class Progression : ScriptableObject
    {
        [SerializeField]
        ProgressionCharacterClass[] characterClasses = null;

        public float GetHealth(CharacterClass characterClass, int level)
        {
           // return 30;
           foreach(ProgressionCharacterClass progressionClass in characterClasses)
            {
                if(progressionClass.characterClass == characterClass)
                {
                    return progressionClass.health[level - 1];
                }
            }
            return 0;
        }

        [System.Serializable]
        class ProgressionCharacterClass
        {
            // int value = 1;
            // string name = "value";

          public CharacterClass characterClass;
          public float[] health;
        }
    }
}