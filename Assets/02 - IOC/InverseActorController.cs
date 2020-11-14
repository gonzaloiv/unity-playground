using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public class InverseActorController : MonoBehaviour
    {

        [Inject] public IInput Input { get; set; }
        public float speed = 10;

        protected virtual void Update()
        {
            transform.Translate(-Input.GetDirection() * speed * Time.deltaTime, 0, 0);
        }

    }

}