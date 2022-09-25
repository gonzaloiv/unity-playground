using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace COR
{

    public class SecondPanel : BasePanel
    {

        [SerializeField] private TextMeshProUGUI label;

        private void Awake()
        {
            label.text = "Not using the input value";
        }

    }

}

