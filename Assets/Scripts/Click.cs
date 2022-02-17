using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField]
    private GameObject destroy_obj;

    public Answer a;
    RaycastHit hit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                /*Debug.Log(hit.transform.gameObject.name);*/
                if (hit.transform.gameObject == gameObject)
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.clear;
                    Destroy(destroy_obj);
                }
                if (gameObject.tag == "1" && gameObject.tag == "5" && gameObject.tag == "6" && gameObject.tag == "7")
                {
                    Destroy(destroy_obj);
                }
            }
        }
    }
}
