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

        [Tooltip("Throttle")]
        [SerializeField]
        float timeBetweenAttack = 2f; //0.6

        float timeSinceLastAttack = 0;

        Transform target;
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
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
                // animator.SetTrigger("attack");
                // GetComponent<Animator>().SetTrigger("attack");
                AttackBehavior();
            }
        }

        private void AttackBehavior()
        {
            if(timeSinceLastAttack > timeBetweenAttack)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0; //reset
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

        //animation event
        void Hit()
        {
            animator.SetTrigger("attack");
        }
    }
}