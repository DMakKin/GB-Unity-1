using UnityEngine;
using UnityEngine.UI;

namespace DM
{
    public class PlayerStaminaUI : BaseObject
    {
        private Image _stamina;
        private PlayerStamina _playerStamina;

        protected override void Awake()
        {
            _playerStamina = FindObjectOfType<PlayerStamina>();
            _stamina = GetComponent<Image>();
        }

        public float Reserve
        {
            set => _stamina.fillAmount = Mathf.Lerp(_stamina.fillAmount, PlayerStamina.currentStamina / _playerStamina.maxStamina, Time.deltaTime);
        }
    }
}