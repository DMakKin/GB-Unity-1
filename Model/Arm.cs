using UnityEngine;

namespace DM
{
    public class Arm : BaseObject
    {
        private bool _isReady = true;
        public float _force = 400;
        public float _coolDown = 5f;
        public Transform _spotOfCast;

        private Magic _fireBallPrefab;
        public ParticleSystem _fireSpray;
        public Magic _chosenPrefab;

        protected override void Awake()
        {
            base.Awake();
            _fireBallPrefab = Resources.Load<Magic>(path: "FireBall");
        }

        public void Fire()
        {
            Invoke("FireLaunch", 0.6f);
        }

        private void FireLaunch()
        {
            if (_isReady)
            {
                var currentMagic = Instantiate(_chosenPrefab, _spotOfCast.position, _spotOfCast.rotation);
                currentMagic.Rbd.AddForce(_spotOfCast.forward * _force);
                _isReady = false;
                Invoke(nameof(CastPreparing), _coolDown);
            }
        }

        private void CastPreparing()
        {
            _isReady = true;
        }     
        
        public void ChangeMagic(int num)
        {
            if (num == 1)
            {
                _fireSpray.Stop();
                _chosenPrefab = _fireBallPrefab;
                Rnd.sharedMaterial.color = Color.red;
            }
            if (num == 2)
            {
                _chosenPrefab = null;
                Rnd.sharedMaterial.color = Color.blue;
            }
            //if (num == 3)
            //{
            //    _chosenPrefab = _summonPrefab;
            //    Rnd.sharedMaterial.color = Color.blue;
            //}
        }

        public void PlayEffect()
        {
            _fireSpray.Play();
        }

        public void StopEffect()
        {
            _fireSpray.Stop();            
        }
    }
}