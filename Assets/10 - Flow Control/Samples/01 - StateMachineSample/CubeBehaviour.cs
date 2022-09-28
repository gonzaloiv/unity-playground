using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlowControl
{

    public class CubeBehaviour : MonoBehaviour, IShowable, IHideable
    {

        [SerializeField] private Button toSphereButton;

        public void Init()
        {
            toSphereButton.gameObject.SetActive(false);
            toSphereButton.onClick.AddListener(() => Router.SetCurrentState("SphereState"));
            gameObject.SetActive(false);
        }

        public void Show()
        {
            toSphereButton.gameObject.SetActive(true);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            toSphereButton.gameObject.SetActive(false);
        }

    }

}