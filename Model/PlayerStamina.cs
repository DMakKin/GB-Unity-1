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
    }    
}