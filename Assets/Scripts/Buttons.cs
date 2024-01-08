using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OpenHome(){
        SceneManager.LoadScene("Home");
    }
    public void OpenLevel(){
        SceneManager.LoadScene("Levels");
    }
    public void OpenNormalPuzzles(){
        SceneManager.LoadScene("Normal");
    }
    public void OpenNormalOne(){
        SceneManager.LoadScene("NormalPuzzleOne");
    }
}
