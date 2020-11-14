using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacedUI
{

    public interface IEntityForm<T>
    {
        Action<T> MessageValueChanged { get; set; }
    }

}