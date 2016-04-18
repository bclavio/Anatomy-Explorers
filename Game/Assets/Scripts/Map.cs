using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    public static GameObject speechObject, viralButton;
    public static Text uiSpeech;
    public static bool doneHeart, doneStomach, doneLiver, doneKidney; 

    void Start() {
        speechObject = GameObject.Find("Text_speech");
        uiSpeech = speechObject.GetComponent<Text>();
        viralButton = GameObject.Find("ButtonViralVilly");
        viralButton.SetActive(false);
    }

   void Update() {
        if (doneHeart && doneStomach && doneLiver && doneKidney) { 
            viralButton.SetActive(true);
            uiSpeech.text = "IMPORTANT MESSEGE! Viral Villy is an infectious virus, and he's on his way to the Heart! You need to stop that bacteria before he arrives at the heart, otherwise the he will infect the entire body through the heart's blood pumping system. Will you do this?";
        }
        else if (doneHeart) {
            // new visualization?
        }
        else if (doneStomach) {
            // new visualization?
        }
        else if (doneLiver) {
            // new visualization?
        }
        else if (doneKidney) {
            // new visualization?
        }
    }

    public void changeImage() {

    }

    // need bool for in the arriving to the expected organ + function in map
    // need function for returning to organ and text (onVisit nad Visited).

    
}
