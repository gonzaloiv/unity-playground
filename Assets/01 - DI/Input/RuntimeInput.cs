using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DI
{

    public class RuntimeInput : IInput
    {

        public virtual int GetDirection()
        {
            int direction = 0;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = -1;
            }
            return direction;
        }

    }

}