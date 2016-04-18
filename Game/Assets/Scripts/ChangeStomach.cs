using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeStomach : MonoBehaviour {

    public static GameObject escapeObj, optionBox1, optionBox2, optionBox3, optionBox4, nextButton;
    public static Text escapeText, uiSpeech, uiName, uiOption1, uiOption2, uiOption3, uiOption4;
    public static Image Carbs;
    public static int optionNum = 0; // for optionbuttons
    public static int next = 0; // increase this for each click, set to zero, when changing character

    void Start() {
        uiSpeech = GameObject.Find("Text_speech").GetComponent<Text>();
        uiName = GameObject.Find("Text_character").GetComponent<Text>();
        uiOption1 = GameObject.Find("TextOption1").GetComponent<Text>();
        uiOption2 = GameObject.Find("TextOption2").GetComponent<Text>();
        uiOption3 = GameObject.Find("TextOption3").GetComponent<Text>();
        uiOption4 = GameObject.Find("TextOption4").GetComponent<Text>();
        Carbs = GameObject.Find("ImageCarbs").GetComponent<Image>();
        optionBox1 = GameObject.Find("ButtonOption (1)");
        optionBox2 = GameObject.Find("ButtonOption (2)");
        optionBox3 = GameObject.Find("ButtonOption (3)");
        optionBox4 = GameObject.Find("ButtonOption (4)");
        nextButton = GameObject.Find("ButtonNext");
        escapeObj = GameObject.Find("ButtonEscapeOrgan");
    }

    // Using variable to differentiate between 4 option buttons
    public void selectOption(int optionButton) {
        optionNum = optionButton; 
    }

    // Variable changed when onclick ButtonNext
    public void increaseNext() {
        next++;
    }

    void Update() {
        if (!Map.doneStomach) {
            ChangeText();
        }
        else {
            optionBox1.SetActive(false);
            optionBox2.SetActive(false);
            optionBox3.SetActive(false);
            optionBox4.SetActive(false);
        }
    }

    public void ChangeText() { // change speech text of characters and options
                               // next button: always plus one (linear conversation)
                               // option buttons 1, 2, 3, 4 (more?), called from ui buttons
        switch (next) {
            case 0:
                uiName.text = "";
                uiSpeech.text = "Someone sitting in a boat, waves to you.";
                Carbs.enabled = false;
                optionBox3.SetActive(false);
                optionBox4.SetActive(false);
                uiOption1.text = "Come closer";
                uiOption2.text = "..";
                break;
            case 1:
                optionBox2.SetActive(false);
                Carbs.enabled = true;
                uiName.text = "Captain Carbs";
                uiSpeech.text = "Ahoy blood mates and welcome to the Stomach. It's all a big acid bowl, so keep your hands and feet inside the boat. Who are you?";
                uiOption1.text = "We are here to help you out.";
                break;
            case 2:
                escapeObj.SetActive(false);
                optionBox2.SetActive(true);
                optionBox3.SetActive(true);
                uiSpeech.text = "Right on! The Stomach has an overflow of viruses, which makes it difficult for me to work. What I have tried so far didn't work, so I could really use some help. Perhaps you need to do it in the correct order.";
                uiOption1.text = "Use oxygen"; // replace the buttons with the negotiation interface! 
                uiOption2.text = "Use proteins";
                uiOption3.text = "Use soldiers";
                next = 2;
                break;
            case 3:
            case 4:
            case 5: // defeat virus I
                next = 3;
                if (optionNum == 1) {
                    uiSpeech.text = "Hmmm, I suppose nothing happened in the Stomach. However, I heard some complains from the Kidney about a rise in blood pressure.";
                }
                else if (optionNum == 2) {
                    uiSpeech.text = "The virsus is still here. But it was nice with some energy.";
                }
                else if (optionNum == 3) {
                    uiSpeech.text = "HOLY SPANOLLI! It looks like that virus did not like those soldiers of the white blood cells, what will you do now?";
                    next = 5;
                }
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10: // defeat virus II
                next = 7;
                if (optionNum == 1) {
                    uiSpeech.text = "Hmmm, I suppose nothing happened in the Stomach. However, I heard some complains from the Kidney about a rise in blood pressure.";
                }
                else if (optionNum == 2) {
                    uiSpeech.text = "The virsus is still here. But it was nice with some energy.";
                }
                else if (optionNum == 3) {
                    uiSpeech.text = "Oooh Yeah! The stomach looks like its getting better, that infested virus did not like those soldiers, what is your next move?";
                    uiOption1.text = "Give big amount of energy";
                    uiOption2.text = "Give medium amount of energy";
                    uiOption3.text = "Give little amount of energy";
                    uiOption4.text = "Use soldiers";
                    optionBox4.SetActive(true);
                    next = 10;
                }
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15: // give energy, change the option buttons into negotiation interface.
                next = 12;
                optionBox1.SetActive(false);
                optionBox2.SetActive(false);
                optionBox3.SetActive(false);
                optionBox4.SetActive(true); uiOption4.text = "We will help another organ";
                if (optionNum == 1) {
                    uiSpeech.text = "You are one of a kind like those white whales that I'll never catch. I will never forget you, blood mates!";
                    next = 15;
                }
                else if (optionNum == 2) {
                    uiSpeech.text = "The Stomach is in good health thanks you. May the wind be with you!"; // is not working/being displayed
                    next = 15;
                }
                else if (optionNum == 3) {
                    uiSpeech.text = "Arww, you are a real pirate so cheap you are.. but the Stomach can now survive and that's what important.";
                    next = 15;
                }
                else if (optionNum == 4) {
                    optionBox1.SetActive(true);
                    optionBox2.SetActive(true);
                    optionBox3.SetActive(true);
                    optionBox4.SetActive(true); uiOption4.text = "Use soldiers";
                    uiSpeech.text = "What happened?";
                }
                break;
            case 16:
                Map.doneStomach = true;
                SceneManager.LoadScene(6); // goto map
                break;
        }
    }
}