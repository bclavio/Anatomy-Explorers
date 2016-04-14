using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
    
    public void ChangeHealthUp()
    {
        Image HealthBar = GetComponent<Image>();
        HealthBar.fillAmount += .1f;
    }
    public void ChangehealthDown()
    {
        Image HealthBar = GetComponent<Image>();
        HealthBar.fillAmount -= .1f;
    }
}
