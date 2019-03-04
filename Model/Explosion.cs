using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DM
{   
    public class Explosion : MonoBehaviour
    {
        [SerializeField] protected float _timeToDestruct = 1;

        void Start()
        {
            Destroy(gameObject, _timeToDestruct);
        }
    }
}
