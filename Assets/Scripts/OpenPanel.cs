using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    /*public Vector3 CameraPos;*/
    
    public void Panel_Open()
    {
        bool isActive = true;
        if (Panel != null)
        {
            isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }

    /*void OnCollisionEnter(Collision Target)
    {
        if (Target.gameObject.CompareTag("TV"))
        {
            Target.gameObject.transform.position = CameraPos;
        }
    }*/
}
