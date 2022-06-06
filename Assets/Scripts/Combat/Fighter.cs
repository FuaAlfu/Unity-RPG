using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

/// <summary>
/// 2022
/// </summary>

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField]
        float weaponRange = 2f;

        Transform target;

        private void Update()
        {
            // bool isInRange = GetIsInRange();
            // if (target != null && !isInRange)
            if (target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public  void Attack(CombatTarget conbatTarget)
        {
            print("boom");
            GetComponent<ActionScheduler>().StartAction(this);
            target = conbatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
    }
}