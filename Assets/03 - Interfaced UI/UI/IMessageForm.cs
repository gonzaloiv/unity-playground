using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacedUI
{

    public interface IMessageForm
    {
        Action<Message> MessageValueChanged { get; set; }
    }

}