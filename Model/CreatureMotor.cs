using UnityEngine;
using UnityEngine.AI;

namespace DM
{
    public class CreatureMotor : MonoBehaviour, IMotor
    {
        //[HideInInspector] public CreatureMotor CrMotor;
        [HideInInspector] public NavMeshAgent CreatureAgent;
        [HideInInspector] public PlayerStamina _player;
        [HideInInspector] public bool readyToGoBack = false;
        private bool alredyGo = false;


        private void Awake()
        {
            //CrMotor = GetComponent<CreatureMotor>();
            CreatureAgent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerStamina>();            
        }             

        public void Move()
        {
            if (!alredyGo)
            {
                alredyGo = true;
                Debug.Log("Отсчет пошел!");
                Invoke(nameof(MoveToPoint), 5f);
            }
            //MoveToPoint(_player.transform.position);            
        }      
        
        public void MoveToPoint()
        {
            readyToGoBack = true;
            alredyGo = false;
        }
    }
}