using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeVilly : MonoBehaviour {

    public static GameObject escapeObj, optionBox1, optionBox2, optionBox3, optionBox4, nextButton;
    public static Text uiSpeech, uiName, uiOption1, uiOption2, uiOption3, uiOption4, nextText;
    public static Image MissLove, MayorMaine, ViralVilly, Octovia;
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
        escapeObj = GameObject.Find("ButtonEscapeOrgan");
        ViralVilly = GameObject.Find("ImageViralVilly").GetComponent<Image>();
        Octovia = GameObject.Find("ImageOctovia").GetComponent<Image>();
        MissLove = GameObject.Find("ImageMissLove").GetComponent<Image>();
        MayorMaine = GameObject.Find("ImageMayorMaine").GetComponent<Image>();
    }

    void Update() {
        ChangeText();
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
        switch (next) {
            case 0:
                optionBox4.SetActive(false);
                MayorMaine.enabled = false;
                Octovia.enabled = false;
                MissLove.enabled = false;
                escapeObj.SetActive(false);
                nextButton.SetActive(false);
                uiName.text = "Viral Villy";
                uiSpeech.text = "Muhahahaha, who are you to oppose me? I am the most infectious criminal in the entire body, muhahahaha. Nobody can stop me for spreading my virus army, NO ONE!";
                optionBox1.SetActive(true); uiOption1.text = "You have something between your teeth.";
                optionBox2.SetActive(true); uiOption2.text = "We will defeat you!";
                optionBox3.SetActive(true); uiOption3.text = "Can you nicely leave the body?";
                break;
            case 1:
                if (optionNum == 1) { // You have something between your teeth.
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiSpeech.text = "This is so humiliating, now feel my fury!"; // Oh, really? Maybe you can help taking it our for me? 1) Go closer 2) We don't trust you
                    uiOption2.text = "We will defeat you!";
                }
                else if (optionNum == 2) { // We will defeat you!
                    next = 2;
                }
                else if (optionNum == 3) { // Can you nicely leave the body?
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiSpeech.text = "Muhahahahahaha! How nice of you to ask, but I will NEVER take orders from such puny creatures. And for your insults, I will remove you from this body.";
                    uiOption2.text = "We will defeat you!";
                }
                break;
            case 2:
                uiSpeech.text = "(do some boss fight)";
                optionBox1.SetActive(true); uiOption1.text = "Small win";
                uiOption2.text = "Medium win";
                optionBox3.SetActive(true); uiOption3.text = "Big win";
                break;  
            case 3:
                if (optionNum == 1) { 
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiSpeech.text = "You might have defeated me for now, but someday I will return.";
                    uiOption2.text = "Next";
                } 
                else if (optionNum == 2) { 
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    ViralVilly.enabled = false;
                    Octovia.enabled = true;
                    uiName.text = "Officer Octovia";
                    uiSpeech.text = "Liver Patrol, take him to the prison and lock him up!";
                    uiOption2.text = "Next";
                }
                else if (optionNum == 3) {
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiSpeech.text = "I can't.. move..";
                    uiOption2.text = "Next";
                }
                break;
            case 4:
                optionBox1.SetActive(false);
                optionBox3.SetActive(false);
                optionBox4.SetActive(false);
                Octovia.enabled = false;
                ViralVilly.enabled = false;
                escapeObj.SetActive(false);
                nextButton.SetActive(false);
                MayorMaine.enabled = true;
                uiSpeech.text = "Mayor Maine: Thank you so much! I don't know what we would have done, if you were not here to help. For your contribution to this body, I hereby give you the title of Bodyguards";
                uiOption2.text = "Next";
                break;
            case 5:
                MayorMaine.enabled = false;
                MissLove.enabled = true;
                uiSpeech.text = "Miss love: You are a fool Mr.Mayor, but thank you so much for helping out. The body is safe for now, do to your teamwork and great thinking. Thank you and so long on your further travels.";
                uiOption2.text = "End game";
                break;
            case 6:
                SceneManager.LoadScene(0); // goto map 
                break;

        }
    }
}
