using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  2022.10.26
/// </summary>

namespace RPG.Combat
{
    [CreateAssetMenu(menuName = "tools/defaultWeapon", fileName = "weapons/make new defaultWeapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField]
        AnimatorOverrideController animatorOverride = null;

        [SerializeField]
        GameObject equippedPrefabe = null;

        [SerializeField]
        float weaponDamage = 25f;

        [SerializeField]
        float weaponRange = 2f;

        public void Spawn(Transform handTransform, Animator animator)
        {
            if (equippedPrefabe != null)
            {
                Instantiate(equippedPrefabe, handTransform);
            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
        }

        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetWeaponRange()
        {
            return weaponRange;
        }
    }
}
