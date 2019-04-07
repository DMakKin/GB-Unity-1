using UnityEngine;

namespace DM
{
    public class PlayerStaminaController : BaseController
    {
        private Player _player;
        private PlayerStaminaUI _playerStaminaUI;

        private KeyCode _save = KeyCode.Alpha6;
        private KeyCode _load = KeyCode.Alpha9;

        public static PlayerStaminaController InstancePSC { get; private set; }

        public PlayerStaminaController()
        {
            InstancePSC = this;
            _player = Object.FindObjectOfType<Player>();
            _playerStaminaUI = Object.FindObjectOfType<PlayerStaminaUI>();
        }

        public override void OnUpdate()
        {
            if (!IsActive || _player == null) return;

            if (Input.GetKeyDown(_save))
            {
                _player.SavePlayer();
            }
            if (Input.GetKeyDown(_load))
            {
                _player.LoadPlayer();
            }

            if (_playerStaminaUI != null)
            {
                _playerStaminaUI.Reserve = Player.currentStamina;
            }

            if (Player.currentStamina < _player.maxStamina)
            {
                Player.currentStamina += _player.regeneration * Time.deltaTime;                
            }

            if (Player.itsContinue)
            {
                _player.LoadPlayer();
                Player.itsContinue = false;
            }
        }

        public bool CheckCurrentStamina(float price)
        {
            if (Player.currentStamina >= price)
            {
                return true;
            }

            return false;                      
        }
    }
}
