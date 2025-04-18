using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butonlar : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void IlkSahne()
    {
        SceneManager.LoadScene(1);


    }
}
