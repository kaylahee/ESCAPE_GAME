using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    [SerializeField]
    public GameObject toOpen;

    [SerializeField]
    public GameObject Alarm;

    [SerializeField]
    public GameObject n1, n2, n3, n4, n5, n6, n7, n8, n9;

    Renderer buttonColor;
    Renderer c1, c2, c3, c4, c5, c6, c7, c8, c9;

    private void Start()
    {
        codeLength = code.Length;
        buttonColor = Alarm.GetComponent<Renderer>();
        c1 = n1.GetComponent<Renderer>();
        c2 = n2.GetComponent<Renderer>();
        c3 = n3.GetComponent<Renderer>();
        c4 = n4.GetComponent<Renderer>();
        c5 = n5.GetComponent<Renderer>();
        c6 = n6.GetComponent<Renderer>();
        c7 = n7.GetComponent<Renderer>();
        c8 = n8.GetComponent<Renderer>();
        c9 = n9.GetComponent<Renderer>();
    }
    void CheckCode()
    {
        if (attemptedCode == code)
        {
            buttonColor.material.color = Color.green;
            StartCoroutine(Open());
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("Wrong Code");
            buttonColor.material.color = Color.red;
            StartCoroutine(Change());
        }
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(1);

        buttonColor.material.color = Color.gray;
        c1.material.color = Color.white;
        c2.material.color = Color.white;
        c3.material.color = Color.white;
        c4.material.color = Color.white;
        c5.material.color = Color.white;
        c6.material.color = Color.white;
        c7.material.color = Color.white;
        c8.material.color = Color.white;
        c9.material.color = Color.white;
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1);

        Destroy(toOpen);
    }

    public void SetValue(string value)
    {
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
