using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlowControl
{

    public class SphereBehaviour : MonoBehaviour, IShowable, IHideable
    {

        [SerializeField] private Button toCubeButton;

        public void Init()
        {
            toCubeButton.gameObject.SetActive(false);
            toCubeButton.onClick.AddListener(() => Router.SetCurrentState("CubeState"));
            gameObject.SetActive(false);
        }

        public void Show()
        {
            toCubeButton.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            toCubeButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

}