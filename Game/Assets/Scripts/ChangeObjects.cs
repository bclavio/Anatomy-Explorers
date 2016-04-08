using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChangeObjects : MonoBehaviour {

    public GameObject speechObject;
    public static Text uiSpeech;
    public bool option1text = false;
    //public static GameObject option1;

    void Start () {
        uiSpeech = speechObject.GetComponent<Text>();
        //option1 = GameObject.Find("ButtonOption (1)");
    }
	
	void Update () {
        ChangeText();


    }

    public void ChangeText() {
        // if option/character is true (+ variable), change test 
        if (option1text) {
            uiSpeech.text = "Text changed into something awesome!";            
        }
    }
}
