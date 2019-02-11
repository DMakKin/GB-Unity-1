using UnityEngine;
using UnityEngine.AI;

namespace DM
{
    public class Creature : BaseObject
    {
        public NavMeshAgent _creatureAgent;
        [HideInInspector] public bool _goToPlayer = true;
        [HideInInspector] public PlayerStamina _player;
        private bool _alreadyChecking = false;

        protected override void Awake()
        {
            base.Awake();

            _creatureAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerStamina>();
        }

        public void CheckDestination()
        {
            if (!_creatureAgent.hasPath && !_alreadyChecking)
            {
                _alreadyChecking = true;
                Debug.Log("Отcчет пошел!");
                Invoke(nameof(ReadyToGoBack), 5f);
            }
        }

        private void ReadyToGoBack()
        {
            _alreadyChecking = false;
            _goToPlayer = true;
        }
    }
}