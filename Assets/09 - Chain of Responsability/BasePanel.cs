using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COR
{

    public abstract class BasePanel : MonoBehaviour
    {

        [SerializeField] private BasePanel successor;
        public virtual void Handle(string value)
        {
            successor.Handle(value);
        }
    }

}