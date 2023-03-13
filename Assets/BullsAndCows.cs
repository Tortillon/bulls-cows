using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BullsAndCows : MonoBehaviour
{
    public TextMeshProUGUI secretWordText;
    public TextMeshProUGUI secretWordLengthtext;
    public TextMeshProUGUI msgText;
    public TMP_InputField inputField;

    public List<string> words= new List<string>();

    private int lives = 3;
    private string secretWord = "Hello";




    // Start is called before the first frame update
    void Start()
    {
        secretWordText.text = "Try and guess.";
        secretWordLengthtext.text = "Secret word length is " + secretWord.Length + ".";
        msgText.text = "Player has " + lives + " lives.";

        Debug.Log("Player has " + lives + " lives.");
        Debug.Log("Secret Word is " + lives + ".");
        Debug.Log("Secret word has " + lives + " letters.");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonClick(TMP_InputField input)
    {
        if (lives > 0)
        {
            if (secretWord.Length == inputField.text.Length)
            {
                int bullsCount = 0;
                for (int i = 0; i<secretWord.Length; i++)
                {
                    if (secretWord[i] == inputField.text[i])
                    {
                        bullsCount++;
                    }
                }
                int cowsCount = 0;
                for (int i=0; i<secretWord.Length; i++)
                {
                    if (secretWord[i] != inputField.text[i] && inputField.text.Contains(secretWord[i]))
                    {
                        cowsCount++;
                    }
                }

                lives--;
                secretWordText.text = "Bulls: " + bullsCount + "cows: " + cowsCount;
                msgText.text = "Player has" + lives + " lives";
            }
            else
            {
                lives--;
                secretWordText.text = "Wrong length";
                msgText.text = "Player has" + lives + " lives";
            }
            inputField.text = "";
        }
        else
        {
            secretWordText.text = "Ypu lost.";
            msgText.text = "Player has " + lives + " lives.";
        }
        
    }
}
