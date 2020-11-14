using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacedUI
{

    public interface IEntityView<T>
    {
        void Show(T instance);
    }

}