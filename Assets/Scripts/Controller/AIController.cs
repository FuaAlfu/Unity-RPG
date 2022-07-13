using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

/// <summary>
/// 2022.7.6
/// </summary>

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private float chaseDistance = 5f; // 5m or 5 unity units.

        Fighter fighter;
        GameObject player;
        Health health;

        // Start is called before the first frame update
        void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (health.Isdead()) return;
            //GameObject player = GameObject.FindWithTag("Player");

            // if (DistanceToPlayer(player) < chaseDistance && fighter.CanAttack(player))
            if (InAttackRangePlayer() && fighter.CanAttack(player))
            {
                //  if(gameObject.tag == "Player") { } //for debugging.
                // print(gameObject.name + "see you");
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }

        //private float DistanceToPlayer(GameObject target)
        //{
        //   return  Vector3.Distance(target.transform.position, transform.position);
        //}

        private bool InAttackRangePlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        //called by unity..
        private void OnDrawGizmos()
        {
            
        }

        private void OnDrawGizmosSelected()
        {
            // Gizmos.color = new Color(); //depth rpga clr
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}