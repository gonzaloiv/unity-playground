using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InterfacedUI
{

    public class MessagePanel : MonoBehaviour, IMessageView
    {

        public TextMeshProUGUI titleLabel;
        public TextMeshProUGUI bodyLabel;

        public virtual void Show(Message message)
        {
            this.titleLabel.text = message.title;
            this.bodyLabel.text = message.body;
        }

    }

}