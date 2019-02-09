using UnityEngine;

namespace DM
{
    public abstract class BaseObject : MonoBehaviour
    {
        //Создаем переменную Rbd типа Rigidbody
        public Rigidbody Rbd { get; private set; }
        //Создаем переменную Tfm типа Transform
        public Transform Tfm { get; private set; }

        public MeshRenderer Rnd { get; private set; }

        //Перед стартом присваиваем переменным свойства объекта
        protected virtual void Awake()
        {
            //Переменной Rbd присваиваем Rigidbody текущего объекта
            Rbd = GetComponent<Rigidbody>();
            //Переменной Tfm присваиваем Transform текущего объекта
            Tfm = transform;

            Rnd = GetComponent<MeshRenderer>();
        }
    }
}