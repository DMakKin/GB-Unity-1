using System.Collections.Generic;
using UnityEngine;

namespace DM
{
    public class SummonController : BaseController
    {
        private SpotOfSummon _spotOfSummon;
        private Camera _mainCamera;
        private Ray ray;
        private RaycastHit hit;

        private List<Creature> Creatures = new List<Creature>();

        private int _rightButton = (int)Mouse.RightButton;
        private KeyCode _summon = KeyCode.R;

        public static SummonController Instance { get; private set; }

        public SummonController()
        {
            Instance = this;
            _spotOfSummon = Object.FindObjectOfType<SpotOfSummon>();
            _spotOfSummon._spotOfSummon.gameObject.SetActive(false);
            _mainCamera = Camera.main;
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
                        Creatures.Add(_spotOfSummon._chosenCreature);
                    }
                }

                if (Input.GetMouseButtonDown(_rightButton))
                {
                    if (Creatures.Count > 0)
                    {
                        for (int i = 0; i < Creatures.Count; i++)
                        {
                            Creatures[i]._goToPlayer = false;
                            Creatures[i]._creatureAgent.SetDestination(hit.point);
                            Creatures[i]._creatureAgent.stoppingDistance = 0;
                        }
                    }
                }

                for (int i = 0; i < Creatures.Count; i++)
                {
                    if (Creatures[i]._goToPlayer)
                    {
                        Creatures[i]._creatureAgent.SetDestination(Creatures[i]._player.transform.position);
                        Creatures[i]._creatureAgent.stoppingDistance = 3;
                        Creatures[i]._creatureAgent.avoidancePriority = i;
                    }
                    else
                    {
                        Creatures[i].CheckDestination();
                    }
                }
            }
        }

        //private void AddCreature(Creature bot)
        //{

        //}

        //private void RemoveCreature(Creature bot)
        //{

        //}

        //            if (_creature.CreatureAgent.remainingDistance < _creature.CreatureAgent.stoppingDistance)

        public void EnableEffect()
        {
            _spotOfSummon.EnableEffect();
        }
    }
}