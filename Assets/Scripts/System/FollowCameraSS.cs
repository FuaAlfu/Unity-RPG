using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.5.10
/// </summary>

namespace RPG.Attribute
{
    public class FollowCameraSS : MonoBehaviour
    {
        //for testing..
        [SerializeField]
        Camera camera;

        [SerializeField]
        Transform target;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}
