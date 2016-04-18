using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLiver : MonoBehaviour {

    public static GameObject escapeObj, optionBox1, optionBox2, optionBox3, optionBox4, nextButton;
    public static Text uiSpeech, uiName, uiOption1, uiOption2, uiOption3, uiOption4, nextText;
    public static Image Octavia, Caroll, Patrol;
    public static int optionNum = 0; // for optionbuttons
    public static int next = 0; // increase this for each click, set to zero, when changing character

    void Start() {
        uiSpeech = GameObject.Find("Text_speech").GetComponent<Text>();
        uiName = GameObject.Find("Text_character").GetComponent<Text>();
        uiOption1 = GameObject.Find("TextOption1").GetComponent<Text>();
        uiOption2 = GameObject.Find("TextOption2").GetComponent<Text>();
        uiOption3 = GameObject.Find("TextOption3").GetComponent<Text>();
        uiOption4 = GameObject.Find("TextOption4").GetComponent<Text>();
        nextText = GameObject.Find("TextNext").GetComponent<Text>();
        optionBox1 = GameObject.Find("ButtonOption (1)");
        optionBox2 = GameObject.Find("ButtonOption (2)");
        optionBox3 = GameObject.Find("ButtonOption (3)");
        optionBox4 = GameObject.Find("ButtonOption (4)");
        nextButton = GameObject.Find("ButtonNext");
        Patrol = GameObject.Find("ImagePatrol").GetComponent<Image>();
        Octavia = GameObject.Find("ImageOfficerOctavia").GetComponent<Image>();
        Caroll = GameObject.Find("ImageCorruptCaroll").GetComponent<Image>();
        escapeObj = GameObject.Find("ButtonEscapeOrgan");
    }
    void Update() {
        //Debug.Log(next);
        if (!Map.doneLiver) {
            ChangeText();
        }
        else {
            optionBox1.SetActive(false);
            optionBox2.SetActive(false);
            optionBox3.SetActive(false);
            optionBox4.SetActive(false);
            nextButton.SetActive(false);
        }
    }
    // Using variable to differentiate between 4 option buttons
    public void selectOption(int optionButton) {
        optionNum = optionButton; 
    }

    // Variable changed when onclick ButtonNext
    public void increaseNext() {
        next++;
    }

    public void ChangeText() { // change speech text of characters and options
                               // next button: always plus one (linear conversation)
                               // option buttons 1, 2, 3, 4 (more?), called from ui buttons
        switch(next){
            case 0:
                uiName.text = "";
                uiSpeech.text = "A group of officers are patrolling here.";
                nextButton.SetActive(false);
                optionBox3.SetActive(false);
                optionBox4.SetActive(false);
                Octavia.enabled = false;
                Caroll.enabled = false;
                uiOption1.text = "Be careful..";
                uiOption2.text = "Approach them.";
                break;
            case 1:
                optionBox2.SetActive(false);
                Patrol.enabled = false;
                Octavia.enabled = true;
                escapeObj.SetActive(true);
                uiName.text = "Officer Octavia";
                uiSpeech.text = "Hey-hey, I see you! You can only earn energy resources, if you're working.. Oh wait, you look new here, my analogies, but maybe you will help out anyway?";
                uiOption1.text = "Help out";

                break;
            case 2:
                escapeObj.SetActive(false);
                optionBox2.SetActive(true);
                uiSpeech.text = "Here's your chance to earn some extra energy resources. There are over 500 different tasks in the Liver, and it requires energy for doing all this. You'll get a handsome share of what you collect, and we will get a healthy Liver. Do you understand?";
                optionBox2.SetActive(true); uiOption2.text = "What do we earn?";
                optionBox1.SetActive(true); uiOption1.text = "Yes, let's go!";
                break;
            case 3:
            case 4:
                if (optionNum == 1) {
                    optionBox1.SetActive(false);
                    optionBox2.SetActive(false);
                    uiSpeech.text = "Let's get to work then. (add casino stuff here!!!!!)."; // add text!!
                    next = 5;
                }
                else if (optionNum == 2) {
                    optionBox2.SetActive(false);
                    uiSpeech.text = "You earn oxygen for your Red Blood Cells and proteins for your Plasma Cells. When you collect these energy resources, you should think of what is good for the body.";                   
                }
                break;
            case 5:
                optionBox4.SetActive(true);
                uiOption4.text = "add questions and casino stuff!! Go to map";
                // add questions and casino stuff!!
                break;
            case 6:
                Map.doneLiver = true;
                SceneManager.LoadScene(6); // goto map
                break;
        }
    }
}