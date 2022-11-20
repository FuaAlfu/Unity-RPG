using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

/// <summary>
/// 2022.11.2
/// </summary>

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    //[SerializeField]
    //Transform target = null;

    [SerializeField]
    float speed = 6.2f;

    [SerializeField]
    bool isHoming = true;

    Health target = null;

    float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //transform.LookAt(player.transform.position);

        transform.LookAt(GetAimLocation());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
       // transform.LookAt(target.position);
       if(isHoming)
        {
            transform.LookAt(GetAimLocation());
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponent<Health>() != target) return;
        target.TakeDamage(damage);
        Destroy(this.gameObject);
    }

    public void SetTarget(Health target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if(targetCapsule == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }
}
