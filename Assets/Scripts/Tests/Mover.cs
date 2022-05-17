using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 2022.5.3
/// </summary>

public class Mover : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent nav;
    Ray lastRay;
   
    // Start is called before the first frame update
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
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
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); //take global and conver it to local
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }

    public void MoveTo(Vector3 destination)
    {
       
        nav.destination = destination;
    }
}
