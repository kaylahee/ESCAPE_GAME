using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveP : MonoBehaviour
{
    ArrayList arraylist = new ArrayList();

    [SerializeField]
    private GameObject num1;
    [SerializeField]
    private GameObject num2;
    [SerializeField]
    private GameObject num3;
    [SerializeField]
    private GameObject num4;

    [SerializeField]
    private GameObject destroy_obj;

    private void Click_Answer()
    {
        if (num1 == arraylist[0])
        {
            if (num2 == arraylist[1])
            {
                if (num3 == arraylist[2])
                {
                    if (num4 == arraylist[3])
                    {
                        Destroy(destroy_obj);
                    }
                }
            }
        }
    }
    
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
                    // Ŭ���� ������ ���� �ٲ��
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.clear;
                    // Ŭ���� ������Ʈ�� �迭�� ����
                    arraylist.Add(gameObject);
                    Click_Answer();
                }
            }
        }
    }
}
