using UnityEngine;

namespace DM
{
    public class PlayerStaminaController : BaseController
    {
        private PlayerStamina _playerStamina;
        private PlayerStaminaUI _playerStaminaUI;

        public static PlayerStaminaController InstancePSC { get; private set; }

        public PlayerStaminaController()
        {
            InstancePSC = this;
            _playerStamina = Object.FindObjectOfType<PlayerStamina>();
            _playerStaminaUI = Object.FindObjectOfType<PlayerStaminaUI>();
        }

        public override void OnUpdate()
        {
            if (!IsActive || _playerStamina == null) return;

            _playerStaminaUI.Reserve = PlayerStamina.currentStamina;

            if (PlayerStamina.currentStamina < _playerStamina.maxStamina)
            {
                PlayerStamina.currentStamina += _playerStamina.regeneration * Time.deltaTime;                
            }
        }

        public bool CheckCurrentStamina(float price)
        {
            if (PlayerStamina.currentStamina >= price)
            {
                return true;
            }

            return false;                      
        }
    }
}
