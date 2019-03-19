using UnityEngine;

namespace DM
{
    public class CreateEnemy : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab = null;
        public void InstantiateEnemy(Vector3 position)
        {
            Instantiate(_enemyPrefab, position, Quaternion.identity);
        }
    }
}