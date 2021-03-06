using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.6.10
/// 
/// combat = old
/// </summary>

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float hp = 100f;

        bool isDead = false;

        public bool Isdead()
        {
            return isDead;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(float damage)
        {
            // hp -= damage;
            hp = Mathf.Max(hp - damage, 0);
            print(damage);
            if (hp <= 0)
            {
                print("enemy is dead..");
                //FindObjectOfType<Fighter>().Cancel();
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}