using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Saving;

/// <summary>
/// 2022.5.3
/// </summary>

namespace RPG.Movement
{

    public class Mover : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField]
        Transform target;

        [SerializeField]
        private float maxSpeed = 6f;

        NavMeshAgent nav;
        Ray lastRay;
        Health health;

        // Start is called before the first frame update
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            //  if(Input.GetMouseButtonDown(0))
            //  {
            //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //   Debug.DrawRay(lastRay.origin,lastRay.direction * 100);
            //   MoveToCursor();
            // }
            // nav.SetDestination(target.position);
            //  nav.destination = target.position;
            nav.enabled = !health.Isdead();
            UpdateAnimator();
        }

        public void StarMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);

         //   GetComponent<Fighter>().Cancel(); //need RPG.combat
            MoveTo(destination,speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            nav.destination = destination;
            nav.speed = maxSpeed * Mathf.Clamp01(speedFraction);  //for protaction perp
            nav.isStopped = false;
        }

        private void UpdateAnimator()
        {
           // Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 velocity = nav.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); //take global and conver it to local
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        public void Cancel()
        {
            nav.isStopped = true;
        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            throw new NotImplementedException();
        }

        //public void Stop()
        //{
        //    nav.isStopped = true;
        //}

        //public void Cancel()
        //{

        //}
    }
}
