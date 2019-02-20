using UnityEngine;

namespace DM
{
    public class PlayerStaminaController : BaseController
    {
        private PlayerStamina _playerStamina;
        private PlayerStaminaUI _playerStaminaUI;

        private KeyCode _save = KeyCode.Alpha6;
        private KeyCode _load = KeyCode.Alpha9;

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

            if (Input.GetKeyDown(_save))
            {
                _playerStamina.SavePlayer();
            }
            if (Input.GetKeyDown(_load))
            {
                _playerStamina.LoadPlayer();
            }

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
