using UnityEngine;

namespace DM
{
    public class FireBall : Magic
    {
        [SerializeField] protected ParticleSystem explEffect;
        [SerializeField] private float timeToDestroy = 10f;
        private float _radius = 6;
        private float _force = 600;

        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, timeToDestroy);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Explosion();
            Destroy(gameObject);
        }

        private void Explosion()
        {
            Instantiate(explEffect, transform.position, transform.rotation);
            Collider[] colladers = Physics.OverlapSphere(transform.position, _radius);

            foreach (Collider nearObj in colladers)
            {
                Rigidbody rb = nearObj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(_force, transform.position, _radius);
                }
            }
        }
    }
}