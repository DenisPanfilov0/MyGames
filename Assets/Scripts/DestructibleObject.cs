using UnityEngine;

namespace DefaultNamespace
{
    public class DestructibleObject : MonoBehaviour
    {

        [SerializeField] private float hpCurrent = 100f;
        public void ReceiveDamage(float damage)
        {
            hpCurrent -= damage;

            if (hpCurrent <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}