using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System;

/// <summary>
/// 2022.7.6
/// </summary>

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private float chaseDistance = 5f; // 5m or 5 unity units.

        [SerializeField]
        private float suspictionTime = 3f;

        [SerializeField]
        ControlPath patrolPath;

        [SerializeField]
        private float waypointTolerance = 1f;

        [SerializeField]
        private float waypointDwellTime = 3f;

        [Range(0,1)]
        [SerializeField]
        private float patrolSpeedFraction = 0.2f;

        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;
        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        int currentWaypointIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            guardPosition = transform.position;
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
                //timeSinceLastSawPlayer = 0;  //we hide it at attack behaviour..
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspictionTime)
            {
                //suspicion state
                SuspicionBehaviour();
            }
            else
            {
                //fighter.Cancel();
                // GuardBehaviour();
                PatrolBehaviour();
            }

            UpdateTimers();
            //TabbedView
        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardPosition;
            if(patrolPath != null)
            {
                if(AtWaypoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }
            // mover.StarMoveAction(guardPosition);
            if(timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                mover.StarMoveAction(nextPosition, patrolSpeedFraction);
            }
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            timeSinceLastSawPlayer = 0;
            fighter.Attack(player);
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