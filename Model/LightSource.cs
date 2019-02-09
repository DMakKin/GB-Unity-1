using UnityEngine;

namespace DM
{
    public class LightSource : BaseObject
    {
        public static ParticleSystem _lightEffect;
        public float time = 5f;
        public static float lightEffectDuration;
        public float staminaNeeded = 30f;
        public bool lightOn = false;
        //public Transform _lightStartPoint;
        //public Transform _lightFinishPoint;

        protected override void Awake()
        {
            base.Awake();
            _lightEffect = GetComponent<ParticleSystem>();
            _lightEffect.Stop();
            lightEffectDuration = time;            
        }


        public void PlayEffect()
        {
            _lightEffect.Play();
            lightOn = true;
        }

        public void StopEffect()
        {
            _lightEffect.Stop();
            lightOn = false;
        }
    }
}