using UnityEngine;

namespace DM
{
    public class UnitMotor : IMotor
    {
        private Transform _character;

        private float _speedMove = 10;
        //private float _jumpPower = 10;
        private float _gravityForce;
        private float _runPercent = 0f;
        private Vector2 _input;
        private Vector3 _moveVector;
        private CharacterController _characterController;
        private Transform _camera;

        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool ClampVerticalRotation = true;
        public float MinimumX = -45F;
        public float MaximumX = 45F;
        public bool Smooth;
        public float SmoothTime = 5f;
        private Quaternion _characterTargetRot;
        private Quaternion _cameraTargetRot;
        private Player _player;

        public UnitMotor(Transform instance)
        {
            _character = instance; //Получаем Transform найденного объекта с CharacterController (Персонажа)
            _characterController = _character.GetComponent<CharacterController>(); //Получаем CC персонажа
            _camera = Camera.main.transform; //Записываем положение камеры

            _characterTargetRot = _character.localRotation; //Записываем поворот персонажа
            _cameraTargetRot = _camera.localRotation; //Записываесм поворот камеры
            _player = Object.FindObjectOfType<Player>();
        }

        public void Move()
        {
            CharecterMove();
            GamingGravity();

            LookRotation(_character, _camera);
        }

        private void CharecterMove()
        {
            if (_characterController.isGrounded) //Проверка земли под ногами
            {                
                _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));  //Вектор направления движения
                Vector3 desiredMove = _character.forward * _input.y + _character.right * _input.x;
                _moveVector.x = desiredMove.x * _speedMove;
                _moveVector.z = desiredMove.z * _speedMove;

                if (Input.GetKey(KeyCode.W) && _runPercent <= 1.0f)
                {
                    _runPercent += 0.05f; 
                }
                else if (!Input.GetKey(KeyCode.W) && _runPercent >= 0.0f)
                {
                    _runPercent -= 0.05f;
                }

                _player._animator.SetFloat("Run", _runPercent, 0.3f, Time.deltaTime);
            }

            _moveVector.y = _gravityForce; //Движение вниз (гравиитация)
            _characterController.Move(_moveVector * Time.deltaTime);
        }

        private void GamingGravity()
        {
            if (!_characterController.isGrounded) _gravityForce -= 30 * Time.deltaTime;
            else _gravityForce = -1;
            if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
            {
                //_gravityForce = _jumpPower;
                _player._animator.SetTrigger("Jump");
            }
        }

        private void LookRotation(Transform character, Transform camera)
        {
            float yRot = Input.GetAxis("Mouse X") * XSensitivity;
            float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

            _characterTargetRot *= Quaternion.Euler(0, yRot, 0f);
            _cameraTargetRot *= Quaternion.Euler(-xRot, 0, 0f);

            if (ClampVerticalRotation)
                _cameraTargetRot = ClampRotationAroundXAxis(_cameraTargetRot);

            if (Smooth)
            {
                character.localRotation = Quaternion.Slerp(character.localRotation, _characterTargetRot,
                    SmoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, _cameraTargetRot,
                    SmoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = _characterTargetRot;
                camera.localRotation = _cameraTargetRot;
            }
        }

        private Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}