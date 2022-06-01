using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

/// <summary>
/// 2022
/// </summary>

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField]
        float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            // bool isInRange = GetIsInRange();
            // if (target != null && !isInRange)
            if (target != null && !GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public  void Attack(CombatTarget conbatTarget)
        {
            print("boom");
            target = conbatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}