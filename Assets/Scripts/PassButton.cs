using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButton : MonoBehaviour
{
    [SerializeField]
    private GameObject destroy_obj;

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
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    Destroy(destroy_obj);
                }
            }
        }
    }
}
