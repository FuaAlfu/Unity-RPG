using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 2022.7.6
/// </summary>

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]
        private float chaseDistance = 5f; // 5m or 5 unity units.


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           GameObject player = GameObject.FindWithTag("Player");
           
            if (DistanceToPlayer(player) < chaseDistance)
            {
              //  if(gameObject.tag == "Player") { } //for debugging.
                print(gameObject.name + "see you");
            }
        }

        private float DistanceToPlayer(GameObject target)
        {
           return  Vector3.Distance(target.transform.position, transform.position);
        }
    }
}