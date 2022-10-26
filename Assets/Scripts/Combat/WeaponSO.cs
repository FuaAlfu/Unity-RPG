using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  2022.10.26
/// </summary>

namespace RPG.Combat
{
    [CreateAssetMenu(menuName = "tools/weapon", fileName = "weapons/make new weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField]
        AnimatorOverrideController animatorOverride = null;

        [SerializeField]
        GameObject weaponPrefabe = null;

        public void Spawn(Transform handTransform, Animator animator)
        {
            Instantiate(weaponPrefabe, handTransform);
            animator.runtimeAnimatorController = animatorOverride;
        }
    }
}
