using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

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

        [SerializeField]
        bool isRightHanded = true;

        [SerializeField]
        Projectile projectile = null;

        public void Spawn(Transform rightHandTransform,Transform leftHandTransform, Animator animator)
        {
            if (equippedPrefabe != null)
            {
                Transform handTransform = GetTransform(rightHandTransform, leftHandTransform);
                Instantiate(equippedPrefabe, handTransform);
            }
            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
        }

        private Transform GetTransform(Transform rightHandTransform, Transform leftHandTransform)
        {
            Transform handTransform;
            if (isRightHanded) handTransform = rightHandTransform;
            else handTransform = leftHandTransform;
            return handTransform;
        }

        public bool HasProjectile()
        {
            return projectile != null;
        }

        public void LunchProjectile(Transform rightHand, Transform leftHand, Health target)
        {
            Projectile projectileInstance = Instantiate(projectile, GetTransform(rightHand,leftHand).position,Quaternion.identity);
            projectileInstance.SetTarget(target, weaponDamage);
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
