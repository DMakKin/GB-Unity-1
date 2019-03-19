using UnityEngine;
using UnityEditor;

namespace DM
{
    public class MagicArmController : BaseController
    {
        private Arm _arm;
        private Player _playerStamina;
        private int _leftButton = (int)Mouse.LeftButton;

        public MagicArmController()
        {
            _arm = Object.FindObjectOfType<Arm>();
            _arm.StopEffect();
            _playerStamina = Object.FindObjectOfType<Player>();
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;

            if (Input.GetMouseButtonDown(_leftButton) && _arm._chosenPrefab != null)
            {
                _playerStamina._animator.SetTrigger("FireBall");
                _arm.Fire();
                
            }

            if (Input.GetMouseButtonDown(_leftButton) && _arm._chosenPrefab == null)
            {
                _playerStamina._animator.SetTrigger("FireStart");
                _arm.PlayEffect();               
            }
            if (Input.GetMouseButtonUp(_leftButton) && _arm._chosenPrefab == null)
            {
                _arm.StopEffect();
                _playerStamina._animator.SetTrigger("FireStop");
            }
        } 
    }
}
