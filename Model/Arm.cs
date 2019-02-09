using UnityEngine;

namespace DM
{
    public class Arm : BaseObject
    {
        private bool _isReady = true;
        public float _force = 400;
        public float _coolDown = 5f;
        public Transform _spotOfCast;

        public Magic _fireBallPrefab;
        public ParticleSystem _fireSpray;
        //public Magic _summonPrefab;
        public Magic _chosenPrefab;

        public void Fire()
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

        //public void Aim()
        //{
        //    //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        //    //float midPoint = (transform.position - Camera.main.transform.position).magnitude * 1f;

        //    //transform.LookAt(ray.origin + ray.direction);
        //}
    }
}