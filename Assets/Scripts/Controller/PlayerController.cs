using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;


/// <summary>
/// 2022.5.15
/// </summary>

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        Ray lastRay;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("done and done !!");
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
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
                if (Input.GetMouseButtonDown(0))
                {
                    //GetComponent<Mover>().MoveTo(hit.point);
                    GetComponent<Mover>().StarMoveAction(hit.point);
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