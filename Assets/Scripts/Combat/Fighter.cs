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

        [SerializeField]
        float weaponDamage = 25f;

        [Tooltip("Throttle")]
        [SerializeField]
        float timeBetweenAttack = 2f; //0.6

        float timeSinceLastAttack = 0;

        Transform target;
        //Health target;
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
           // if (target.Isdead()) return;
           // if(GetComponent<Health>().Isdead())

            if (!GetIsInRange())
            {
                 GetComponent<Mover>().MoveTo(target.position);
               // GetComponent<Mover>().MoveTo(target.transform.position);
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
                Hit();
            }
        }

        //animation event
        void Hit()
        {
            // animator.SetTrigger("attack");

             Health healthComponent = target.GetComponent<Health>();
             healthComponent.TakeDamage(weaponDamage);

          //  target.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            // return Vector3.Distance(transform.position, target.position) < weaponRange;
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public  void Attack(CombatTarget conbatTarget)
        {
            print("boom");
            GetComponent<ActionScheduler>().StartAction(this);
             target = conbatTarget.transform;
           // target = GetComponent<Health>();
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }

       
    }
}