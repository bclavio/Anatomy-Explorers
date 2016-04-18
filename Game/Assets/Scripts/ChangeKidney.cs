using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeKidney : MonoBehaviour {

    public static GameObject escapeObj, optionBox1, optionBox2, optionBox3, optionBox4;
    public static Text uiSpeech, uiName, uiOption1, uiOption2, uiOption3, uiOption4;
    public static Image charObj1, charObj2, charObj3, charObj4, charObj5;
    public static int optionNum = 0; // for optionbuttons
    public static int characterNum, characterCtrl; // for characterbuttons  and  control of dialogue
    public static int next = 0; // increase this for each click, set to zero, when changing character
    public static int solution = 0; // reach 3: can travel to new organ 
    public Transform target, org1, org2, org3; // move characters to center
    public static float step, speedScaling;
    public static bool doneSal, doneFrieda, doneSam, highPress;
    public static Vector3 newScale, orgScale;
    // IMPORTANT: don't casually change the names of the variables (then the switch will not work): 
    // optionBox1, optionBox2, optionBox3, optionBox3, 
    // uiOption1, uiOption2, uiOption3, uiOption4, 
    // optionNum1, optionNum2. optionNum3, optionNum4

    void Start() {
        uiSpeech = GameObject.Find("Text_speech").GetComponent<Text>();
        uiName = GameObject.Find("Text_character").GetComponent<Text>();
        uiOption1 = GameObject.Find("TextOption1").GetComponent<Text>();
        uiOption2 = GameObject.Find("TextOption2").GetComponent<Text>();
        uiOption3 = GameObject.Find("TextOption3").GetComponent<Text>();
        uiOption4 = GameObject.Find("TextOption4").GetComponent<Text>();
        optionBox1 = GameObject.Find("ButtonOption (1)");
        optionBox2 = GameObject.Find("ButtonOption (2)");
        optionBox3 = GameObject.Find("ButtonOption (3)");
        optionBox4 = GameObject.Find("ButtonOption (4)");
        charObj1 = GameObject.Find("ImagePressurePeter").GetComponent<Image>();
        charObj2 = GameObject.Find("ImageSaltySal").GetComponent<Image>();
        charObj3 = GameObject.Find("ImageFitFrieda").GetComponent<Image>();
        charObj4 = GameObject.Find("ImageSmokeySam").GetComponent<Image>();
        charObj5 = GameObject.Find("ImagePressurePeter (1)").GetComponent<Image>();
        escapeObj = GameObject.Find("ButtonEscapeOrgan");
        step = 20 * Time.deltaTime;
        speedScaling = 4.2f;
        newScale = new Vector3(2.3F, 2.3F, 2.3F);
        orgScale = new Vector3(1.0F, 1.0F, 1.0F);
    }

    void Update() {
        //Debug.Log(next);
        if (!Map.doneKidney) {
            ChangeText();
        }
        else {
            optionBox1.SetActive(false);
            optionBox2.SetActive(false);
            optionBox3.SetActive(false);
            optionBox4.SetActive(false);
            charObj1.enabled = false;
            charObj2.enabled = false;
            charObj3.enabled = false;
            charObj4.enabled = false;
            charObj5.enabled = true;
            uiName.text = "Pressure Peter";
            uiSpeech.text = "Hey " + ChangeHeart.saveName + ", thanks for the help last time. The blood pressure is stabelized and the Kidney is good, but I'll give you a call when I need you.";
        }
    }

    // Using variable to differentiate between 4 option buttons
    public void selectOption(int optionButton) {
        optionNum = optionButton; 
    }

    // Using variable to differentiate between characters (buttons)
    public void selectCharacter(int characterButton) {
        characterNum = characterButton; 
    }

    // Variable increase if onclick ButtonNext
    public void increaseNext() {
        next++;
    }

    public void ChangeText() { // change speech text of characters and options
                               // next button: always plus one (linear conversation)
                               // option buttons 1, 2, 3, 4 (more?), called from ui buttons

        // IMPORTANT: don't casually change the names of the variables (then the switch will not work): 
        // optionBox1, optionBox2, optionBox3, optionBox3, 
        // uiOption1, uiOption2, uiOption3, uiOption4, 
        // optionNum1, optionNum2. optionNum3, optionNum4
        switch (next) {              
            case 0:
                uiName.text = "Pressure Peter";
                uiSpeech.text = "What are you doing here? Arhh, I don't have time for this! I don't know what to do with the high blood pressure.. Wait a second, are you here to help?";
                optionBox3.SetActive(false);
                optionBox4.SetActive(false);
                charObj2.enabled = false;
                charObj3.enabled = false;
                charObj4.enabled = false;
                charObj5.enabled = false;
                optionBox1.SetActive(true);  uiOption1.text = "What is the problem?"; // doesn't work
                optionBox2.SetActive(true);  uiOption2.text = "Yes, we will help.";
                break;
            case 1:
            case 2:
                if (optionNum <= 1) {
                    uiName.text = "Pressure Peter";
                    optionBox1.SetActive(false);
                    uiSpeech.text = "I don't know. The blood pressure is too high. I can't get it down. Oh my, oh my, what do I do.. Wait, you blood cells are great at solving problems, you can help me!";
                    Debug.Log("work");
                    if (highPress) optionNum = 2;
                }
                else if (optionNum >= 2) {
                    escapeObj.SetActive(false);
                    optionBox1.SetActive(false);
                    optionBox2.SetActive(false);
                    uiName.text = "Pressure Peter";
                    uiSpeech.text = "Talk to the other micro-organisms here in the Kidney and figure out how to lower the blood pressure.";
                    charObj1.enabled = false;
                    charObj2.enabled = false;
                    charObj3.enabled = false;
                    charObj4.enabled = false;
                    if (!doneSal) charObj2.enabled = true;
                    if (!doneFrieda) charObj3.enabled = true;
                    if (!doneSam) charObj4.enabled = true;
                    charObj2.transform.localScale = orgScale;
                    charObj3.transform.localScale = orgScale;
                    charObj4.transform.localScale = orgScale;
                    charObj2.transform.position = org1.position;
                    charObj3.transform.position = org2.position;
                    charObj4.transform.position = org3.position;
                    next = 3;
                    characterCtrl = 0;
                    characterNum = 0;
                    optionNum = 0;
                }
                break;
            case 3:
            case 4:
                if (characterNum == 1) { // ASK SAL
                    charObj3.enabled = false;
                    charObj4.enabled = false;
                    charObj2.transform.localScale = Vector3.Lerp(charObj2.transform.localScale, newScale, speedScaling * Time.deltaTime);
                    charObj2.transform.position = Vector3.MoveTowards(charObj2.transform.position, target.position, step);
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "What do you want? Can't you see I'm busy salting up this place?";
                    optionBox1.SetActive(true); uiOption1.text = "Who are you?"; // Option Sal.1
                    optionBox2.SetActive(true); uiOption2.text = "Why do you salt up this place?"; // Option Sal.2
                    optionBox3.SetActive(true); uiOption3.text = "Sorry to bother you, we will be leaving now"; // Option Sal.3 // go to high blood pressure????????????????????????
                }
                else if (characterNum == 2) { // ASK FRIEDA
                    charObj2.enabled = false;
                    charObj4.enabled = false;
                    charObj3.transform.localScale = Vector3.Lerp(charObj3.transform.localScale, newScale, speedScaling * Time.deltaTime);
                    charObj3.transform.position = Vector3.MoveTowards(charObj3.transform.position, target.position, step);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "Hello, hello, I'm Frieda and I love to run, dance, push ups and all things that gets me in good shape. Who are you, and how can I help you?";
                    optionBox1.SetActive(true); uiOption1.text = "Do you know anything about high blood pressure?"; // Option F.1 
                    optionBox2.SetActive(true); uiOption2.text = "Could you show some excercises?"; // Option F.2
                    optionBox3.SetActive(true); uiOption3.text = "Would you please stop excexising?"; // Option F.3
                    // sorry to bother you option?
                }
                else if (characterNum == 3) { // ASK SAM
                    charObj4.transform.localScale = Vector3.Lerp(charObj4.transform.localScale, newScale, speedScaling * Time.deltaTime);
                    charObj4.transform.position = Vector3.MoveTowards(charObj4.transform.position, target.position, step);
                    charObj2.enabled = false;
                    charObj3.enabled = false;
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "Hello *kopf* *kopf*! I can't really see you through the all the smoke, but if you can tell me what you want, I might be able to help you.";
                    optionBox1.SetActive(true); uiOption1.text = "Sorry to bother you, you keep on smoking."; // Option Sam.1 // 3
                    optionBox2.SetActive(true); uiOption2.text = "Would you mind stop smoking?"; // Option Sam.1 // 4
                    optionBox3.SetActive(true); uiOption3.text = "Why do you smoke?"; // Option Sam.3 
                    optionBox4.SetActive(true); uiOption4.text = "Do you know anything about high blood pressure?"; // Option Sam.4
                }
                break;
            case 5:
            case 6:
                ///////////////////////// SAL /////////////////////////
                if (characterNum == 1 && optionNum == 1) { // Option Sal.1: Who are you?
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "Who am I? Well I'm just a whole lot of salt, having a skedaddle here. Why are you asking?";
                    optionBox1.SetActive(true); uiOption1.text = "Do you know anything about high blood pressure?"; // Option SAl.1.1 
                    optionBox2.SetActive(true); uiOption2.text = "Will you add some more salt to the kidneys?"; // Option SAl.1.2
                    optionBox3.SetActive(true); uiOption3.text = "Do you mind reducing your amount of salt?"; // Option SAl.1.3  
                    characterCtrl = 2;
                    next = 6; 
                }
                else if (characterNum == 1 && optionNum == 2) { // Option Sal.2: Why do you salt up this place?
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "The more salt that the body consumes, the more I spread. That is just how it works.";
                    optionBox1.SetActive(true); uiOption1.text = "So, who are you?"; // Option SAl.2.1
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    // goes back to Sal.1
                }
                else if (characterNum == 1 && optionNum == 3) { // Option Sal.3: Sorry to bother you, we will be leaving now.
                    optionBox1.SetActive(false);
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "Go on then, and don't come back unless it's important!";
                    /*charObj2.transform.localScale = Vector3.Lerp(charObj2.transform.localScale, orgScale, speedScaling * Time.deltaTime);
                    charObj2.transform.position = Vector3.MoveTowards(charObj2.transform.position, org1.position, step);
                    charObj3.SetActive(true);
                    charObj4.SetActive(true);
                    */
                    travel(); // or go to high blood pressure?
                }

                ///////////////////////// FRIEDA /////////////////////////
                else if (characterNum == 2 && optionNum == 1) { // Option F.1: Do you know anything about high blood pressure?
                    optionBox1.SetActive(false);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "Good question, but I am not sure. One thing I know is that all this salt is clustering the room in here, so it's hard to excersice. What do you suggest I do?";
                    uiOption2.text = "You can excercise more "; // Option F.1.1 
                    uiOption3.text = "Why don't you just stop excercising?"; // Option F.1.2
                    characterCtrl = 1;
                }
                else if (characterNum == 2 && optionNum == 2) { // Option F.2: Could you show some excercises? // DONE
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "You bet I can! Here we go.";
                    optionBox2.SetActive(true); uiOption2.text = "Thank you!"; // Option F.2.1 -> low blood pressure
                    next = 9;
                    characterCtrl = 4;
                    doneFrieda = true;
                }
                else if (characterNum == 2 && optionNum == 3) { // Option F.3: Would you please stop excexising? // DONE
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "Okay, I will stop for now then.";
                    optionBox1.SetActive(true); uiOption1.text = "Thanks."; // F.3.1 -> high blood pressure
                    characterCtrl = 3;
                    next = 9;
                }

                ///////////////////////// SAM /////////////////////////   
                else if (characterNum == 3 && optionNum == 1) { // Option Sam.2: Sorry to bother you, you keep on smoking.
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "So long, mate.";
                    optionBox1.SetActive(true); uiOption1.text = "Leave."; // F.3.1 -> high blood pressure
                    characterCtrl = 3;
                    next = 9;
                }
                else if (characterNum == 3 && optionNum == 2) { // Option Sam.1: Would you mind stop smoking
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "Well I have thought and tried many times *kopf*, but it is very hard when you have smoked as long as I have. However if you think that i should *kopf* stop, then I will try much harder this time.";
                    optionBox1.SetActive(true); uiOption1.text = "We don't care."; // -> high blood pressure 3 && 1
                    optionBox2.SetActive(true); uiOption2.text = "We will support you, if you quit smoking."; // -> low blood pressure 4 && 2
                    next = 6;
                    
                }
                else if (characterNum == 3 && optionNum == 3) { // Option Sam.3: Why do you smoke? 
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "All I know is that it gets harder to stop *kopf* *kopf*, the longer you do it. And it smells horrible, right?";
                    optionBox1.SetActive(true); uiOption1.text = "Well it is your choice, so long then.";
                    optionBox2.SetActive(true); uiOption2.text = "Have you tried to stop smoking then?";
                    optionBox3.SetActive(true); uiOption3.text = "Yeah";
                    next = 6;
                }
                else if (characterNum == 3 && optionNum == 4) { // Option Sam.4: Do you know anything about high blood pressure?
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "Blood pressure *kopf*! That I do NOT care about. *kopf* As long as I don't have to exercise *kopf*.";
                    optionBox1.SetActive(true); uiOption1.text = "Sorry for asking, just continue your business";
                    optionBox2.SetActive(true); uiOption2.text = "Could you please stop smoking?";
                }
                break;
            case 7:
            case 8:
            case 9:
                ///////////////////////// SAL /////////////////////////
                if (characterNum == 1 && characterCtrl == 2 && optionNum == 1) { // Option Sal.1.1: Do you know anything about high blood pressure?
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "I have heard somewhere, that it might help if you excercise once in a while. But honestly I don't really care.";
                    optionBox1.SetActive(false);
                    uiOption2.text = "Let's add some more salt to the kidneys!"; // Option Sal.1.1.2 
                    uiOption3.text = "Do you mind reducing your amount of salt?"; // Option Sal.1.1.3 
                }
                else if (characterNum == 1 && characterCtrl == 2 && optionNum == 2) { // Option Sal.1.2: Will you add some more salt to the kidneys?
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "Don't mind if I do.";
                    optionBox1.SetActive(true); uiOption1.text = "Thanks."; // low pressure 
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    characterCtrl = 3;
                    next = 9;
                }
                else if (characterNum == 1 && characterCtrl == 2 && optionNum == 3) { // Option Sal.1.3: Do you mind reducing your amount of salt?
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Salty Sal";
                    uiSpeech.text = "Hmmm, well I don't want to, but if you really think I should, then I suppose I could stop spreading salt?";
                    optionBox2.SetActive(true); uiOption2.text = "Yes, we would appreciate if you did that."; // high pressure
                    doneSal = true;
                    characterCtrl = 4;
                    next = 9;
                    doneSal = true;
                }

                ///////////////////////// FRIEDA /////////////////////////
                else if (characterNum == 2 && optionNum == 2) { // Option F.2: Could you show some excercises? // DONE
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "You are definitely right! I will excercise until the salt is gone! Thank you for the awesome advice."; // 
                    optionBox2.SetActive(true); uiOption2.text = "You are welcome!"; // Option F.2.1 -> low blood pressure
                    next = 9;
                    characterCtrl = 4;
                    doneFrieda = true;
                }
                else if (characterNum == 2 && optionNum == 3) { // Option F.3: Would you please stop excexising? // DONE
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Fit Frida";
                    uiSpeech.text = "Okay, I will stop for now then.";
                    uiOption1.text = "Thanks."; // F.3.1 -> high blood pressure
                    characterCtrl = 3;
                    next = 9;
                }

                ///////////////////////// SAM /////////////////////////
                else if (characterNum == 3 && optionNum == 1) { // Option Sam.2: Sorry to bother you, you keep on smoking.
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "So long, mate.";
                    optionBox1.SetActive(true); uiOption1.text = "Leave."; // F.3.1 -> high blood pressure
                    characterCtrl = 3;
                    next = 9;
                }
                else if (characterNum == 3 && optionNum == 2) { // Option Sam.1: Would you mind stop smoking/
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "I might be able to do it.";
                    optionBox2.SetActive(true); uiOption2.text = "Thanks."; // -> low blood pressure
                    characterCtrl = 4;
                    next = 9;
                    doneSam = true;
                }
                else if (characterNum == 3 && optionNum == 3) { // Option Sam.1: Yeah (it smells) 
                    optionBox1.SetActive(false);
                    optionBox3.SetActive(false);
                    optionBox4.SetActive(false);
                    uiName.text = "Smokey Sam";
                    uiSpeech.text = "I'm so sorry *kopf* *kopf*. I will stop smoking now then. You guys should not be affected by my choice *kopf*. However, it was nice to meet you guys and good luck on your journey.";
                    optionBox2.SetActive(true); uiOption2.text = "Thank you."; // -> low blood pressure
                    characterCtrl = 4;
                    next = 9;
                    doneSam = true;
                }
                break;
            case 10:
                if (characterCtrl == 3 && optionNum == 1) { // High blood pressure
                    charObj2.enabled = false;
                    charObj3.enabled = false;
                    charObj4.enabled = false;
                    optionBox2.SetActive(false);
                    optionBox3.SetActive(false);
                    uiName.text = "Pressure Peter";
                    uiSpeech.text = "OH NO NO NO! The blood pressure is even higher now. Please go fix this! Im so STRESSED.";
                    optionBox1.SetActive(true); uiOption1.text = "Go back"; // doesn't work
                    charObj1.enabled = true;
                    highPress = true;
                }
                else if (characterCtrl == 4 && optionNum == 2) { // Low blood pressure
                    if (doneSal && doneFrieda && doneSam) {
                        charObj2.enabled = false;
                        charObj3.enabled = false;
                        charObj4.enabled = false;
                        optionBox1.SetActive(false);
                        optionBox2.SetActive(false);
                        optionBox3.SetActive(false);
                        uiName.text = "Pressure Peter";
                        uiSpeech.text = "Pheeeew, what a relief. Now the blood pressure is more stabilized. Thank you so much.";
                        optionBox4.SetActive(true); uiOption4.text = "We will help another organ"; // doesn't work
                        charObj5.enabled = true;
                    }
                    else {
                        charObj2.enabled = false;
                        charObj3.enabled = false;
                        charObj4.enabled = false;
                        optionBox1.SetActive(false);
                        optionBox3.SetActive(false);
                        uiName.text = "Pressure Peter";
                        uiSpeech.text = "Brilliant! Hurry, get the others to help too.";
                        optionBox2.SetActive(true); uiOption2.text = "Go back";
                        charObj1.enabled = true;
                    }
                }
                break;
            case 11:
                travel();
                break;
        }       
    }

    public void travel() {
        if (doneSal && doneFrieda && doneSam) {
            Map.doneKidney = true;
            SceneManager.LoadScene(6); // goto map
        }
       else {
            next = 2;
        }
    }
}