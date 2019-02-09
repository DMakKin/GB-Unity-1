using UnityEngine;

namespace DM
{
    public class FireBall : Magic
    {
        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("Boom!");
            Destroy(gameObject);
        }
    }
}