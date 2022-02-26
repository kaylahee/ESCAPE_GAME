using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAction : MonoBehaviour
{
    [SerializeField]
    public GameObject Panel;

    public void Panel_Open()
    {
        bool isActive = true;
        if (Panel != null)
        {
            isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
    }
}
