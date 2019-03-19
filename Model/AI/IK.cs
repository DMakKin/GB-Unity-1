using UnityEngine;

namespace DM
{
    public class IK : BaseObject
    {
        private Animator _animator;
        private IKControl _iKControl;

        public Transform _head;
        //public Transform _rightHand;
        //public Transform _leftHand;
        public Transform _target = null;
        //public Transform _rObstacle;
        //public Transform _lObstacle;

        public float _lookDistance = 10;
        public float _takeDistance = 2;

        public bool iSeeTarget = false;
        public bool iCanTakeTarget = true;

        //public LayerMask _rayLayer;

        private void OnValidate()
        {            
            _animator = GetComponentInChildren<Animator>();
            //_rightHand = _animator.GetBoneTransform(HumanBodyBones.RightHand);
            //_leftHand = _animator.GetBoneTransform(HumanBodyBones.LeftHand);
        }

        private void OnAnimatorIK()
        {
            if (!_animator) return;
            if (iSeeTarget)
            {
                if (_target != null)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_target.position);
                }
            }
            if (iCanTakeTarget /*&& _rObstacle != null && _lObstacle != null*/)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                _animator.SetIKPosition(AvatarIKGoal.RightHand, _target.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, _target.rotation);

                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _target.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _target.rotation);
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

            }
        }
    }
}