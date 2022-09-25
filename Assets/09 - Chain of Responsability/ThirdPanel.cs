using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace COR
{

    public class ThirdPanel : BasePanel
    {

        [SerializeField] private TextMeshProUGUI label;

        public override void Handle(string value)
        {
            label.text = value;
        }

    }

}