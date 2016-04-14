using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour {

    public void ChangeToScene(int scene) {
        SceneManager.LoadScene(scene); // goto map
    }
}
