using UnityEngine;

namespace DM
{
    public class SpotOfSummon : BaseObject
    {

        public ParticleSystem _spot;
        private Creature _summonPrefab;
        [HideInInspector] public SpotOfSummon _spotOfSummon;
        public LayerMask _maskForSummon;
        [HideInInspector] public bool IsActive = false;
        [HideInInspector] public Creature _chosenCreature;        

        
        protected override void Awake()
        {
            base.Awake();
            _spotOfSummon = FindObjectOfType<SpotOfSummon>();
            _summonPrefab = Resources.Load<Creature>(path: "Creature");
        }

        public void EnableEffect()
        {
            if (IsActive)
            {
                _spotOfSummon.gameObject.SetActive(false);
                IsActive = false;
            }
            else
            {
                _spotOfSummon.gameObject.SetActive(true);
                IsActive = true;
            }
        }

        public void SummonCreature()
        {
            _chosenCreature = Instantiate(_summonPrefab, _spot.transform.position, _spot.transform.rotation);
        }
    }
}