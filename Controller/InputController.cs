using UnityEngine;

namespace DM
{
    public class InputController : BaseController
    {
        private KeyCode _codeLight = KeyCode.F;        
        private KeyCode _fireBall = KeyCode.Alpha1;
        private KeyCode _fireSpray = KeyCode.Alpha2;
        private KeyCode _summon = KeyCode.Alpha3;
        
        private int magicType = 0;
        private int magicCount = 2;
        private Arm _arm;
        private Player _playerStamina;
        

        public InputController()
        {
            _arm = Object.FindObjectOfType<Arm>();
            _playerStamina = Object.FindObjectOfType<Player>();         
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_codeLight) && !GameManager.Instance.LightSourceController.IsActive)
            {
                _playerStamina._animator.SetTrigger("CastLight");
                GameManager.Instance.LightSourceController.On();
            }

            if (Input.GetKeyDown(_fireBall))
            {
                _arm.ChangeMagic(1);
            }

            if (Input.GetKeyDown(_fireSpray))
            {
                _arm.ChangeMagic(2);
            }

            if (Input.GetKeyDown(_summon))
            {
                SummonController.Instance.EnableEffect();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (magicType < magicCount)
                {
                    magicType++;
                }
                else
                {
                    magicType = 1;
                }
                _arm.ChangeMagic(magicType);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (magicType <= 1)
                {
                    magicType = magicCount;
                }
                else
                {
                    magicType--;
                }
                _arm.ChangeMagic(magicType);
            }            
        }
    }
}
