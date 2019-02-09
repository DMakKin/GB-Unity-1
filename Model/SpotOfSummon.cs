﻿using UnityEngine;

namespace DM
{
    public class SpotOfSummon : BaseObject
    {

        public ParticleSystem _spot;
        public Creature _summonPrefab;
        [HideInInspector] public SpotOfSummon _spotOfSummon;
        public LayerMask _maskForSummon;
        [HideInInspector] public bool IsActive = false;

        
        protected override void Awake()
        {
            base.Awake();
            _spotOfSummon = FindObjectOfType<SpotOfSummon>();
        }

        public void EnableEffect()
        {
            //Debug.Log(IsActive);
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
            Creature _chosenCreature = Instantiate(_summonPrefab, _spot.transform.position, _spot.transform.rotation);
        }
    }
}