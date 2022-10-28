using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.10.28
/// </summary>

namespace RPG.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] WeaponSO weapon = null;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<Fighter>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
