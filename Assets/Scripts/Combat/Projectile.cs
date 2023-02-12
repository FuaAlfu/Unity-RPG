using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Attribute;

/// <summary>
/// 2022.11.2
/// </summary>

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        GameObject player;

        //[SerializeField]
        //Transform target = null;

        [SerializeField]
        float speed = 6.2f;

        [SerializeField]
        private GameObject prefabeHitEffect = null;

        [SerializeField]
        float maxLifeTime = 10f;

        [SerializeField]
        GameObject[] destroyOnHit = null;

        [SerializeField]
        float lifeAfterImpact = 1.9f;


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
            if (isHoming && !target.Isdead())
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider c)
        {
            if (c.GetComponent<Health>() != target) return;
            if (target.Isdead()) return;
            target.TakeDamage(damage);
            speed = 0;
            if (prefabeHitEffect != null)
            {
                Instantiate(prefabeHitEffect, GetAimLocation(), transform.rotation);
            }

            foreach (GameObject toDestroy in destroyOnHit)
            {
                Destroy(toDestroy);
            }
            Destroy(this.gameObject, lifeAfterImpact);
        }

        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;

            Destroy(gameObject, maxLifeTime);
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }
    }
}