using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.7.17
/// </summary>

namespace RPG.Control
{
    public class ControlPath : MonoBehaviour
    {
        const float WAYPOINT_GIZMOS_RADIUS = 0.3f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                // int j = i + 1; //i++
                int j = GetNextIndex(i); 
                Gizmos.DrawSphere(GetWaypoint(i), WAYPOINT_GIZMOS_RADIUS);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));

                // Gizmos.DrawSphere(transform.GetChild(i).position, WAYPOINT_GIZMOS_RADIUS);
                // transform.GetChild(transform).position
            }
        }

        public int GetNextIndex(int i)
        {
            if(i + 1 == transform.childCount)
            {
                return 0;
            }
            return i + 1; //i++
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}