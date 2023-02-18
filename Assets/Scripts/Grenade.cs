using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float delay = 3f;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float explosionForce = 700f;
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private float damage = 100f;

        bool hasExploded = false;
        float countdown;

        private void Start()
        {
            countdown = delay;

        }

        private void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExploded)
            {
                Explode();
                hasExploded = true;
            }
        }

        void Explode()
        {
            var explosionEffectInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosionEffectInstance, 2f);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders)
            {
                
                
                
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                    var dm = rb.GetComponent<DestructibleObject>();
                    if (dm != null)
                    {
                        dm.ReceiveDamage(damage);
                    }
                }
                
                
            }
            Destroy(gameObject);
        }
    }
}