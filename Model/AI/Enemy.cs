using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

namespace DM
{
    public class Enemy : BaseObject
    {
        private float _lookRadius = 10f;
        [HideInInspector] public NavMeshAgent _enemyAgent;

        protected override void Awake()
        {
            base.Awake();

            _enemyAgent = GetComponent<NavMeshAgent>();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _lookRadius);
        }

    }
}