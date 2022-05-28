using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController1 : MonoBehaviour

{
    public Player player;

    public InputField textEntryField;

    public Text logText;

    public Text currentText;

    public Action[] actions;



    [TextArea]
    public string introText;




    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();


    }

    public void Update()
    {
        
    }




    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        //why does this line disable connection texts from view?
        //I forgot to add the plus sign
        description += player.currentLocation.GetItemsText();
        if (additive)
         
            currentText.text = currentText.text + "\n" + description;
        else
        currentText.text = description;
        


    }

    //creating a text entered-method
    public void TextEntered()
    {

        //calling the text from text entered function

        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
        Debug.Log("text entered");
    }
        //wiring up to the text input field
        //adds the last action entered, pushes text up
        void LogCurrentText()
        {
            logText.text += "\n\n";
            logText.text += currentText.text;

            //show the text player entered and change color
            logText.text += "\n\n";
            logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
        }

        //adding inputting process. Input string is the parameter
    
    void ProcessInput(string input)
    {
        input = input.ToLower();

        //adding a split method
        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach (Action action in actions)

        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }

        }

    }


}
    