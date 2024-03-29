using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Attribute;


/// <summary>
/// 2022.5.15
/// </summary>

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Ray lastRay;
        Health health;

        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            if (health.Isdead()) return;

            if (InteractWithCombat()) return;
            if(InteractWithMovement()) return;
           // print("done and done !!");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                GameObject targetGameObject = target.gameObject;
                //if (!GetComponent<Fighter>().CanAttack(target))
                  if (!GetComponent<Fighter>().CanAttack(targetGameObject))
                  {
                    continue;
                  }
                if(Input.GetMouseButton(0))  //GetMouseButtonDown
                {
                    // GetComponent<Fighter>().Attack(target);
                    GetComponent<Fighter>().Attack(targetGameObject);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            // Ray ray = GetRay();
            RaycastHit hit;
            // bool hasHit = Physics.Raycast(ray, out hit);
            bool hasHit = Physics.Raycast(GetRay(), out hit);
            if (hasHit)
            {
                //nav.SetDestination(hit.point);
                //  nav.destination = hit.point;
                if (Input.GetMouseButton(0))  //GetMouseButtonDown
                {
                    //GetComponent<Mover>().MoveTo(hit.point);
                    GetComponent<Mover>().StarMoveAction(hit.point, 1f); //1f means full speed..
                }
                return true;
            }
            return false;
        }

        //private bool InteractWithMovement()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        //        MoveToCursor();
        //    }
        //}

        //private void MoveToCursor()
        //{
        //   // Ray ray = GetRay();
        //    RaycastHit hit;
        //    // bool hasHit = Physics.Raycast(ray, out hit);
        //    bool hasHit = Physics.Raycast(GetRay(), out hit);
        //    if (hasHit)
        //    {
        //        //nav.SetDestination(hit.point);
        //        //  nav.destination = hit.point;
        //            GetComponent<Mover>().MoveTo(hit.point);
        //    }
        //}

        private static Ray GetRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}