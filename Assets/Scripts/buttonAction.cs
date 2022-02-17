using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAction : MonoBehaviour
{
    [SerializeField]
    public GameObject Panel;
    // 카메라 비추는거 다르게
    /*[SerializeField]
    public Camera cam;*/

    /*public void buttonMethod()
    {
        Debug.Log("Okay");
    }*/

    public void Panel_Open()
    {
        bool isActive = true;
        if (Panel != null)
        {
            isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            /*if (Panel.tag == "Canvas_Q4")
            {
                cam.depth = 2;
            }*/
        }
    }
}
