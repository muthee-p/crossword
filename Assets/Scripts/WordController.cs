using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Letter;


public class WordController : MonoBehaviour
{
    public TMP_InputField[] input;
    //[SerializeField] private TMP_InputField sharedInputField;
    [SerializeField] private List<Image> imageFields = new List<Image>();
    private List<string> _inputs = new List<string>();
    private List<string> _isCorrect = new List<string>();
    public string isComplete = "";
   

   private void Start()
    {
        SetupInputFieldListeners();
    }
    
     void Update(){
        _inputs.Clear(); 
        _isCorrect.Clear();
        
        foreach (var item in input)
        { 
            if (!string.IsNullOrEmpty(item.text))
            {
                _inputs.Add(item.text);
               
            }
            string isCorrect = item.GetComponent<LetterScript>().isCorrect;
            if(isCorrect == "correct"){
                 _isCorrect.Add(isCorrect);
            }
             
        }
        if(_inputs.Count == input.Length && _inputs.Count == _isCorrect.Count){
           
            CheckCorrectness();
        }
        else{
            return;
        }      
    }
    public void CheckCorrectness(){
         foreach (var img in imageFields)
        {
            isComplete = "complete";
            img.color = Color.green;
            DisableAllInputFields();
        }
    }
    void DisableAllInputFields()
    {
        foreach (TMP_InputField inputField in input)
        {
            inputField.interactable = false;
        }
    }
    private void SetupInputFieldListeners()
    {
        for (int i = 0; i < input.Length; i++)
        {
            int currentIndex = i;
            input[i].onValueChanged.AddListener(delegate { OnInputValueChanged(currentIndex); });
        }
    }
    private void OnInputValueChanged(int currentIndex)
    {
        if (currentIndex < input.Length - 1 && !string.IsNullOrEmpty(input[currentIndex].text))
        {
            input[currentIndex + 1].Select();
        }
        if (currentIndex > 0 && string.IsNullOrEmpty(input[currentIndex].text))
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                input[currentIndex - 1].Select();
                input[currentIndex - 1].ForceLabelUpdate(); 
            }
        }
    }
   
}
