using UnityEngine;

namespace DM
{
    public class GameManager : MonoBehaviour
    {        
        public PlayerController PlayerController { get; private set; }        
        public InputController InputController { get; private set; }
        public LightSourceController LightSourceController { get; private set; }
        public PlayerStaminaController PlayerStaminaController { get; private set; }
        public MagicArmController MagicArmController { get; private set; }
        public SummonController SummonController { get; private set; }
        public EnemyController EnemyController { get; private set; }
        public IKControl IKControl { get; private set; }
        public PortalController PortalController { get; private set; }
        public TeleporterController TeleporterController { get; private set; }
                    
        private BaseController[] Controllers;

        public static GameManager Instance { get; private set; }
        
        public Camera _landCamera;
        public Camera _caveCamera;
        public Material _landCameraMaterial;
        public Material _caveCameraMaterial;
        
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
            IKControl = new IKControl();
            PortalController = new PortalController();
            TeleporterController = new TeleporterController();

            PlayerController.On();
            InputController.On();
            LightSourceController.Off();
            PlayerStaminaController.On();
            MagicArmController.On();
            SummonController.On();
            EnemyController.On();
            IKControl.On();
            PortalController.On();
            TeleporterController.On();

            Controllers = new BaseController[10];            
            Controllers[0] = PlayerController;
            Controllers[1] = InputController;
            Controllers[2] = LightSourceController;
            Controllers[3] = PlayerStaminaController;
            Controllers[4] = MagicArmController;
            Controllers[5] = SummonController;
            Controllers[6] = EnemyController;
            Controllers[7] = IKControl;
            Controllers[8] = PortalController;
            Controllers[9] = TeleporterController;

            if (_caveCamera.targetTexture != null)
            {
                _caveCamera.targetTexture.Release();
            }

            _caveCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            _caveCameraMaterial.mainTexture = _caveCamera.targetTexture;

            if (_landCamera.targetTexture != null)
            {
                _landCamera.targetTexture.Release();
            }

            _landCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            _landCameraMaterial.mainTexture = _landCamera.targetTexture;
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