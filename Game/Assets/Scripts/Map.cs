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
            uiSpeech.text = "Viral Villy: Muhahahaha, I have taken the heart and soon I'll take it all!";
            
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

    // need bool for in the arriving to the expected organ + function in map
    // need function for returning to organ and text (onVisit nad Visited).

    
}
