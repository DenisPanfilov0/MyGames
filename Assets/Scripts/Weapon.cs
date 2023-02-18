using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{


    public class Weapon : MonoBehaviour
    {

        [SerializeField] private float damage = 5f;
        [SerializeField] private float force = 4f;
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float spreadConfig = 0.1f;
        [SerializeField] private GameObject muzzleFlashPrefab;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var flashEffect = Instantiate(muzzleFlashPrefab, shootPoint);
                Destroy(flashEffect, 0.2f);

                var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
                var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
                var spread = new Vector3(randomX, randomY, 0f);
                Vector3 direction = shootPoint.forward + spread;

                if (Physics.Raycast(shootPoint.position, direction, out var hit))
                {

                    var impactEffect = Instantiate(impactPrefab, hit.point,
                        Quaternion.LookRotation(hit.normal, Vector3.up));
                    Destroy(impactEffect, 0.2f);

                    var destructible = hit.transform.GetComponent<DestructibleObject>();
                    if (destructible != null)
                    {
                        destructible.ReceiveDamage(damage);
                    }

                    var rb = hit.transform.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}