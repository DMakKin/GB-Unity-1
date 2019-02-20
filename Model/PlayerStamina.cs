using UnityEngine;

namespace DM
{
    public class PlayerStamina : BaseObject
    {

        public float maxStamina = 100;
        public static float currentStamina;
        public int regeneration = 1;

        protected override void Awake()
        {
            base.Awake();
            currentStamina = maxStamina;
        }

        public void SavePlayer()
        {            
            SaveSystem.SavePlayer(this);
        }
        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            currentStamina = data._currentStamina;

            Vector3 position;
            position.x = data._position[0];
            position.y = data._position[1];
            position.z = data._position[2];
            transform.position = position;
        }
    }    
}