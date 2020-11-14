using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public class ActorController : MonoBehaviour
    {

        [Inject] public IInput Input { get; set; }
        public float speed = 3;

        protected virtual void Update()
        {
            transform.Translate(Input.GetDirection() * speed * Time.deltaTime, 0, 0);
        }

    }

}