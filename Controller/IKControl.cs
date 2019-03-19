using UnityEngine;

namespace DM
{
    public class IKControl : BaseController
    {        
        private IK _playerIK;

        private Vector3 _hPos;
        private Vector3 _tPos;

        private Vector3 _rhPos;
        private Vector3 _lhPos;

        private Vector3 _rhFpos;
        private Vector3 _lhFpos;
        private Quaternion _rhFrot;
        private Quaternion _lhFrot;

        //private float _smoothness = 0.5f;
        //[SerializeField] private float _rayLength = 2;

        public IKControl()
        {
            _playerIK = Object.FindObjectOfType<IK>();
        }            

        public override void OnUpdate()
        {
            if (Time.frameCount % 2 == 0)
            {
                _hPos = _playerIK._head.TransformPoint(Vector3.zero);
                _tPos = _playerIK._target.TransformPoint(Vector3.zero);
                _rhPos = _playerIK._target.TransformPoint(Vector3.zero);
                _lhPos = _playerIK._target.TransformPoint(Vector3.zero);

                float dis = Vector3.Distance(_hPos, _tPos);

                if (dis <= _playerIK._lookDistance)
                {
                    _playerIK.iSeeTarget = true;
                }
                else
                {
                    _playerIK.iSeeTarget = false;
                }

                //Debug.DrawRay(_playerIK._head.position, Vector3.forward, Color.red);

                //if (Physics.Raycast(_rhPos, Vector3.forward, out var rightHit, _rayLength, _playerIK._rayLayer))
                //{
                //    _rhFpos = Vector3.Lerp(_playerIK._head.position, rightHit.point, _smoothness);
                //    _rhFrot = Quaternion.FromToRotation(_playerIK.transform.up, rightHit.normal) * _playerIK.transform.rotation;
                //    _playerIK._rObstacle = rightHit.collider.gameObject.transform;
                //}
                //if (Physics.Raycast(_lhPos, Vector3.forward, out var leftHit, _rayLength, _playerIK._rayLayer))
                //{
                //    _lhFpos = Vector3.Lerp(_playerIK._leftHand.position, leftHit.point, _smoothness);
                //    _lhFrot = Quaternion.FromToRotation(_playerIK.transform.up, leftHit.normal) * _playerIK.transform.rotation;
                //    _playerIK._lObstacle = leftHit.collider.gameObject.transform;
                //    Debug.Log(leftHit.collider.gameObject.transform);
                //}

                if (dis <= _playerIK._takeDistance)
                {
                    _playerIK.iCanTakeTarget = true;
                }
                else
                {
                    _playerIK.iCanTakeTarget = false;
                }
            }
        }
    }
}