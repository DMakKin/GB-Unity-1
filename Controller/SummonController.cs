using UnityEngine;

namespace DM
{
    public class SummonController : BaseController
    {
        private SpotOfSummon _spotOfSummon;
        private Camera _mainCamera;
        private Ray ray;
        private RaycastHit hit;
        private CreatureMotor _creature;
        private int dt = 2;

        private int _rightButton = (int)Mouse.RightButton;
        private KeyCode _summon = KeyCode.R;

        public static SummonController Instance { get; private set; }

        public SummonController()
        {
            Instance = this;
            _spotOfSummon = Object.FindObjectOfType<SpotOfSummon>();
            _spotOfSummon._spotOfSummon.gameObject.SetActive(false);
            _mainCamera = Camera.main;
            _creature = Object.FindObjectOfType<CreatureMotor>();
        }

        public override void OnUpdate()
        {
            if (!IsActive) return;
            
            ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, _spotOfSummon._maskForSummon)) 
            {
                if (_spotOfSummon.IsActive)
                {
                    _spotOfSummon._spot.transform.position = hit.point;
                    if (Input.GetKeyDown(_summon))
                    {
                        _spotOfSummon.SummonCreature();
                    }
                }
                if (Input.GetMouseButtonDown(_rightButton))
                {
                    Debug.Log(hit.point);                                       
                    _creature.readyToGoBack = false;
                    _creature.CreatureAgent.SetDestination(hit.point);
                }
            }
            if (_creature.CreatureAgent.transform.position.x <= hit.point.x + dt && _creature.CreatureAgent.transform.position.x >= hit.point.x - dt
                && _creature.CreatureAgent.transform.position.y <= hit.point.y + dt && _creature.CreatureAgent.transform.position.y >= hit.point.y - dt
                && _creature.CreatureAgent.transform.position.z <= hit.point.z + dt && _creature.CreatureAgent.transform.position.z >= hit.point.z - dt)
            {
                _creature.Move();
            }
            if (_creature.readyToGoBack)
            {
                _creature.CreatureAgent.SetDestination(_creature._player.transform.position);
            }
        } 

        public void EnableEffect()
        {
            _spotOfSummon.EnableEffect();
        }
    }
}