using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    CodeLock codelock;
    int reachRange = 100;

    Renderer buttonColor;

    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Press();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    void Press()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, reachRange))
        {
            codelock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

            /*Debug.Log(gameObject);*/

            if (codelock != null)
            {
                string value = hit.transform.name;
                codelock.SetValue(value);
                hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }
}




