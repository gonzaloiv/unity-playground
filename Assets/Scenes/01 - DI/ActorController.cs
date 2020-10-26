using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DI
{

    public class ActorController : MonoBehaviour
    {

        public IInput Input { get; set; }
        public float speed = 3;

        protected virtual void Update()
        {
            transform.Translate(Input.GetDirection() * speed * Time.deltaTime, 0, 0);
        }

    }

}