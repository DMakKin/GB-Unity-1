using UnityEngine;

namespace DM
{
    public class Main : MonoBehaviour
    {        
        public PlayerController PlayerController { get; private set; }        
        public InputController InputController { get; private set; }
        public LightSourceController LightSourceController { get; private set; }
        public PlayerStaminaController PlayerStaminaController { get; private set; }
        public MagicArmController MagicArmController { get; private set; }
        public SummonController SummonController { get; private set; }
        public EnemyController EnemyController { get; private set; }
                    
        private BaseController[] Controllers;

        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            Cursor.lockState = CursorLockMode.Locked;

            PlayerController = new PlayerController(new UnitMotor(FindObjectOfType<CharacterController>().transform));
            InputController = new InputController();
            LightSourceController = new LightSourceController();
            PlayerStaminaController = new PlayerStaminaController();
            MagicArmController = new MagicArmController();
            SummonController = new SummonController();
            EnemyController = new EnemyController();

            PlayerController.On();
            InputController.On();
            LightSourceController.Off();
            PlayerStaminaController.On();
            MagicArmController.On();
            SummonController.On();
            EnemyController.On();

            Controllers = new BaseController[7];            
            Controllers[0] = PlayerController;
            Controllers[1] = InputController;
            Controllers[2] = LightSourceController;
            Controllers[3] = PlayerStaminaController;
            Controllers[4] = MagicArmController;
            Controllers[5] = SummonController;
            Controllers[6] = EnemyController;            
        }

        private void FixedUpdate()
        {
            for (var index = 0; index < Controllers.Length; index++)
            {
                var controller = Controllers[index];
                controller.OnUpdate();
            }
        }
    }
}