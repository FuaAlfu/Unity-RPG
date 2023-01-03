using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using System;

/// <summary>
/// 2022
/// </summary>

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        //[SerializeField]
        //float weaponRange = 2f;

        //[SerializeField]
        //float weaponDamage = 25f;

        [SerializeField]
        string defualtWeaponName = "Unarmed";

        [Tooltip("Throttle")]
        [SerializeField]
        float timeBetweenAttack = 2f; //0.6

        [SerializeField]
        Transform rightHandTransform = null;

        [SerializeField]
        Transform leftHandTransform = null;

        [SerializeField]
        WeaponSO defaultWeapon = null;

        WeaponSO currentWeapon = null;

        //  float timeSinceLastAttack = 0;
        float timeSinceLastAttack = Mathf.Infinity;

        Transform target;
        //Health target;
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            //EquipWeapon(defaultWeapon);

            WeaponSO weapon = Resources.Load<WeaponSO>(defualtWeaponName);
            EquipWeapon(weapon);
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
                 GetComponent<Mover>().MoveTo(target.position, 1f);  //1f means full speed..
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

        public void EquipWeapon(WeaponSO weapon)
        {
            // if (weapon == null) return;
            currentWeapon = weapon;
                //Instantiate(equippedPrefabe, rightHandTransform);
                Animator animator = GetComponent<Animator>();
            // animator.runtimeAnimatorController = weaponOverride;
            weapon.Spawn(rightHandTransform, leftHandTransform, animator);
        }

        private void AttackBehavior()
        {
            transform.LookAt(target);
            //transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttack)
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
          //  if (target == null) { return; } //example
            
             Health healthComponent = target.GetComponent<Health>();
            if (healthComponent == null) { return; }
            if(currentWeapon.HasProjectile())
            {
                currentWeapon.LunchProjectile(rightHandTransform, leftHandTransform, healthComponent);
            }
            else
            {
                // healthComponent.TakeDamage(weaponDamage);
                healthComponent.TakeDamage(currentWeapon.GetDamage());

                //  target.TakeDamage(weaponDamage);
            }
        }

        void Shoot()
        {
            Hit();
        }

       // public bool CanAttack(CombatTarget combatTarget)
          public bool CanAttack(GameObject combatTarget)
        {
            if(combatTarget == null){ return false; }

            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.Isdead();
        }

        private bool GetIsInRange()
        {
            // return Vector3.Distance(transform.position, target.position) < weaponRange;
            // return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetWeaponRange();
        }

        //  public  void Attack(CombatTarget conbatTarget)
        public void Attack(GameObject conbatTarget)
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
            GetComponent<Mover>().Cancel();
        }

       
    }
}