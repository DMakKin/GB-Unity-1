using UnityEngine;

namespace DM
{
    public class TeleporterCave : MonoBehaviour
    {
        public Transform _player;
        public Transform _receiver;

        public bool playerIsOverlapping = false;
        
        private void OnTriggerEnter (Collider other)
        {
            if (other.tag == "Player")
            {
                playerIsOverlapping = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                playerIsOverlapping = false;
            }
        }
    }
}