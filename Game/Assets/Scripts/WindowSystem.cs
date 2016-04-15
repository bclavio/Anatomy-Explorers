using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowSystem : MonoBehaviour {


     int firstvalue = 0;
     int secondvalue = 0;

    public int total;
    int temp;

    void Start()
    {
        GameObject.Find("Amount").GetComponent<Text>().text = total.ToString();
    }

	public void FirstUp()
    {
        if(firstvalue >= 0 && firstvalue <= 9)
            firstvalue += 1;
        if(firstvalue > 9)
            firstvalue = 0;
        GameObject.Find("FirstNumber").GetComponent<Text>().text = firstvalue.ToString();
        temp = total - (firstvalue * 10 + secondvalue);
        if (temp < 0)
            temp = 0;
        GameObject.Find("Amount").GetComponent<Text>().text = temp.ToString();
    }

    public void FirstDown()
    {
        if(firstvalue >= 0 && firstvalue <= 9)
            firstvalue -= 1;
        if(firstvalue < 0)
            firstvalue = 9;
        GameObject.Find("FirstNumber").GetComponent<Text>().text = firstvalue.ToString();
        temp = total - (firstvalue * 10 + secondvalue);
        if (temp < 0)
            temp = 0;
        GameObject.Find("Amount").GetComponent<Text>().text = temp.ToString();
    }

    public void SecondUp()
    {
        if(secondvalue >= 0 && secondvalue <= 9)
            secondvalue += 1;
        if (secondvalue > 9)
            secondvalue = 0;
        GameObject.Find("SecondNumber").GetComponent<Text>().text = secondvalue.ToString();
        temp = total - (firstvalue * 10 + secondvalue);
        if (temp < 0)
            temp = 0;
        GameObject.Find("Amount").GetComponent<Text>().text = temp.ToString();
    }

    public void SecondDown()
    {
        if(secondvalue >= 0 && secondvalue <= 9)
            secondvalue -= 1;
        if (secondvalue < 0)
            secondvalue = 9;
        GameObject.Find("SecondNumber").GetComponent<Text>().text = secondvalue.ToString();
        temp = total - (firstvalue * 10 + secondvalue);
        if (temp < 0)
            temp = 0;
        GameObject.Find("Amount").GetComponent<Text>().text = temp.ToString();
    }
}
