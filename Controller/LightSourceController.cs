using UnityEngine;
using UnityEditor;

namespace DM
{
    public class LightSourceController : BaseController
    {
        private LightSource _lightSource;        
        bool enoughStamina = false;

        public LightSourceController()
        {
            _lightSource = Object.FindObjectOfType<LightSource>();
        }

        public override void OnUpdate()
        {
            if (!IsActive || _lightSource == null) return;

            enoughStamina = PlayerStaminaController.InstancePSC.CheckCurrentStamina(_lightSource.staminaNeeded);

            if (!_lightSource.lightOn && enoughStamina)
            {
                _lightSource.PlayEffect();
                Player.currentStamina -= _lightSource.staminaNeeded;
            }
            
            if (LightSource.lightEffectDuration <= 0)
            {                
                Main.Instance.LightSourceController.Off();
                _lightSource.StopEffect();
                LightSource.lightEffectDuration = _lightSource.time;
            }

            LightSource.lightEffectDuration -= Time.deltaTime;            
        }
    }
}
