using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField]
    private GameObject first;
    [SerializeField]
    private GameObject second;
    [SerializeField]
    private GameObject third;
    [SerializeField]
    private GameObject fourth;
    [SerializeField]
    private GameObject destroy_obj;

    public void Click_Answer()
    {
        if (gameObject.tag == "1" && gameObject.tag == "5" && gameObject.tag == "6" && gameObject.tag == "7")
        {
            Destroy(destroy_obj);
        }
    }
}
