using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.11.2
/// </summary>

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Transform target = null;

    [SerializeField]
    float speed = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
       // transform.LookAt(target.position);
        transform.LookAt(GetAimLocation());
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        return target.position + Vector3.up * targetCapsule.height / 2;
    }
}
