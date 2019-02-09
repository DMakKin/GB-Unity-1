using UnityEngine;
using UnityEditor;

namespace DM
{
    public class MagicArmController : BaseController
    {
        private Arm _arm;
        private int _leftButton = (int)Mouse.LeftButton;

        public MagicArmController()
        {
            _arm = Object.FindObjectOfType<Arm>();
            _arm.StopEffect();
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;

            if (Input.GetMouseButton(_leftButton) && _arm._chosenPrefab != null)
            {
                _arm.Fire();
            }

            if (Input.GetMouseButtonDown(_leftButton) && _arm._chosenPrefab == null)
            {
                _arm.PlayEffect();               
            }
            if (Input.GetMouseButtonUp(_leftButton))
            {
                _arm.StopEffect();
            }
        } 
    }
}
