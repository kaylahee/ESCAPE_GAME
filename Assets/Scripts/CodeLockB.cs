using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockB : MonoBehaviour
{
    int codeLength1;
    int placeInCode1;

    public string code1 = "";
    public string attemptedCode1;

    [SerializeField]
    public GameObject toOpen1;

    [SerializeField]
    public GameObject Alarm1;

    [SerializeField]
    public GameObject N1, N2, N3, N4, N5, N6, N7, N8, N9, N10, N11, N12, N13, N14, N15, N16, N17, N18, N19, N20, N21, N22, N23, N24, N25, N26;

    Renderer buttonColor;
    Renderer C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15 ,C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26;

    private void Start()
    {
        codeLength1 = code1.Length;
        buttonColor = Alarm1.GetComponent<Renderer>();
        C1 = N1.GetComponent<Renderer>();
        C2 = N2.GetComponent<Renderer>();
        C3 = N3.GetComponent<Renderer>();
        C4 = N4.GetComponent<Renderer>();
        C5 = N5.GetComponent<Renderer>();
        C6 = N6.GetComponent<Renderer>();
        C7 = N7.GetComponent<Renderer>();
        C8 = N8.GetComponent<Renderer>();
        C9 = N9.GetComponent<Renderer>();
        C10 = N10.GetComponent<Renderer>();
        C11 = N11.GetComponent<Renderer>();
        C12 = N12.GetComponent<Renderer>();
        C13 = N13.GetComponent<Renderer>();
        C14 = N14.GetComponent<Renderer>();
        C15 = N15.GetComponent<Renderer>();
        C16 = N16.GetComponent<Renderer>();
        C17 = N17.GetComponent<Renderer>();
        C18 = N18.GetComponent<Renderer>();
        C19 = N19.GetComponent<Renderer>();
        C20 = N20.GetComponent<Renderer>();
        C21 = N21.GetComponent<Renderer>();
        C22 = N22.GetComponent<Renderer>();
        C23 = N23.GetComponent<Renderer>();
        C24 = N24.GetComponent<Renderer>();
        C25 = N25.GetComponent<Renderer>();
        C26 = N26.GetComponent<Renderer>();
    }
    void CheckCode()
    {
        if (attemptedCode1 == code1)
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
        C1.material.color = Color.white;
        C2.material.color = Color.white;
        C3.material.color = Color.white;
        C4.material.color = Color.white;
        C5.material.color = Color.white;
        C6.material.color = Color.white;
        C7.material.color = Color.white;
        C8.material.color = Color.white;
        C9.material.color = Color.white;
        C9.material.color = Color.white;
        C10.material.color = Color.white;
        C11.material.color = Color.white;
        C12.material.color = Color.white;
        C13.material.color = Color.white;
        C14.material.color = Color.white;
        C15.material.color = Color.white;
        C16.material.color = Color.white;
        C17.material.color = Color.white;
        C18.material.color = Color.white;
        C19.material.color = Color.white;
        C20.material.color = Color.white;
        C21.material.color = Color.white;
        C22.material.color = Color.white;
        C23.material.color = Color.white;
        C24.material.color = Color.white;
        C25.material.color = Color.white;
        C26.material.color = Color.white;
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1);

        Destroy(toOpen1);
    }
    public void SetValue(string value)
    {
        placeInCode1++;

        if (placeInCode1 <= codeLength1)
        {
            attemptedCode1 += value;
        }

        if (placeInCode1 == codeLength1)
        {
            CheckCode();

            attemptedCode1 = "";
            placeInCode1 = 0;
        }
    }
}
