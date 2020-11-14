using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InterfacedUI
{

    public class MessageInputView : MonoBehaviour, IMessageView
    {

        public TMP_InputField titleField;
        public TMP_InputField bodyField;

        public virtual void Show(Message message)
        {
            this.titleField.text = message.title;
            this.bodyField.text = message.body;
        }

    }

}