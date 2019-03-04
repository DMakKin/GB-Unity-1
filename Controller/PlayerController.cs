using UnityEngine;

namespace DM
{
    public class PlayerController : BaseController
    {
        private IMotor _motor;
        //private Arm _arm;
        //private float turnSpeed = 20f;
        //private Ray ray;
        //private Camera _mainCamera;

        public PlayerController(IMotor motor)
        {
            //_arm = Object.FindObjectOfType<Arm>();
            //_mainCamera = Camera.main;
            _motor = motor;
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;
            _motor.Move();
            //LookOnCursor();
        }

        //private void LookOnCursor()
        //{
        //    ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        //    Vector3 dir = Input.mousePosition - _arm.transform.position;
        //    Quaternion lookRotation = Quaternion.LookRotation(dir);
        //    Vector3 rotation = Quaternion.Lerp(_arm.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //    _arm.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        //}
    }
}
