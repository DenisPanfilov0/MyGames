using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ThrowGrenade : MonoBehaviour

    {
        [SerializeField] private float throwForce = 5f;
        [SerializeField] private GameObject grenadePrefab;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GrenadeThrowForward();
            }
        }

        public void GrenadeThrowForward()
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
    }
            
             
}