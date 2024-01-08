using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] words;
    public GameObject gameOverPanel;
    private List<string> _isComplete = new List<string>();

    void Start(){
        gameOverPanel.SetActive(false);
        
    }
    void Update(){
         _isComplete.Clear();
        foreach (var word in words)
        {
            string isComplete = word.GetComponent<WordController>().isComplete;
            if(isComplete == "complete"){
                _isComplete.Add(isComplete);
            }
            if(_isComplete.Count == words.Length){
            gameOverPanel.SetActive(true);
            }
        }
        
    }
}
