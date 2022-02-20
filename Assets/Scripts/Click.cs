using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField]
    private GameObject destroy_obj;

    [SerializeField]
    private GameObject obj;

    ArrayList arraylist = new ArrayList();

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
                    /*arraylist.Add(gameObject);*/

                    /*if (arraylist[0] == "N_8")
                    {
                        if (arraylist[1] =="N_6")
                        {
                            if(arraylist[2] == "N_4")
                            {
                                Destroy(destroy_obj);
                            }
                            *//*else
                            {
                                obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            }*//*
                        }
                        *//*else
                        {
                            obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        }*//*
                    }
                    else
                    {
                        obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    }*/
                }
            }
        }
    }

    /*private void FindAnswer()
    {
        if (gameObject.tag == "N_8")
        {
            if (gameObject.tag == "N_6")
            {
                if (gameObject.tag == "N_4")
                {
                    Destroy(destroy_obj);
                }
                else
                {
                    obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
            }
            else
            {
                obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
        else
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }*/
}
