using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeGameSceneToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("SelectGame");
    }
    public void ChangeGameSceneToF()
    {
        SceneManager.LoadScene("F_Stage");
    }
    public void ChangeGameSceneToS()
    {
        SceneManager.LoadScene("S_Stage");
    }
    public void ChangeGameSceneToEnd()
    {
        SceneManager.LoadScene("End");
    }
}
