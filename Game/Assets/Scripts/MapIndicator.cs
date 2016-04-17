using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapIndicator : MonoBehaviour {

	public void Change()
    {
        SceneManager.LoadScene("Map2");
    }

    public void Return()
    {
        SceneManager.LoadScene("MapScene");
    }
}
