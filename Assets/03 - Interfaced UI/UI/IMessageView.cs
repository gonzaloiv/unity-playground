using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacedUI
{

    public interface IMessageView
    {
        void Show(Message message);
    }

}