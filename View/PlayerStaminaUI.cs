using UnityEngine;
using UnityEngine.UI;

namespace DM
{
    public class PlayerStaminaUI : BaseObject
    {
        private Image _stamina;
        private Player _playerStamina;

        protected override void Awake()
        {
            _playerStamina = FindObjectOfType<Player>();
            _stamina = GetComponent<Image>();
        }

        public float Reserve
        {
            set => _stamina.fillAmount = Mathf.Lerp(_stamina.fillAmount, Player.currentStamina / _playerStamina.maxStamina, Time.deltaTime);
        }
    }
}