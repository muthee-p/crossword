using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Letter{
     public class LetterScript : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private LetterCase letter;
        //[SerializeField]private Image img;
        
        public string isCorrect = "";

       public void Awake(){
            inputField.characterLimit=1;
            inputField.onValueChanged.AddListener(TextHandler);
        }

        public void TextHandler(string arg0)
        {
            if(arg0 == letter.Uppercase || arg0 == letter.LowerCase){
                isCorrect = "correct";
                //wordController.GetComponent<WordController>().CheckCorrectness();
                return;
            }
            //img.color =Color.red;
        }
    }
}
