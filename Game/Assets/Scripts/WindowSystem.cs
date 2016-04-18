using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowSystem : MonoBehaviour {


    public static int firstvalueOx = 0;
    public static int secondvalueOx = 0;
    public static int firstvalueSol = 0;
    public static int secondvalueSol = 0;
    public static int firstvaluePro = 0;
    public static int secondvaluePro = 0;

    public static int oxygen = 50;
    public static int soldier = 100;
    public static int protein = 20;

    int tempOx, tempSol, tempPro;

    void Start()
    {
        GameObject.Find("AmountOx").GetComponent<Text>().text = oxygen.ToString();
        GameObject.Find("AmountSol").GetComponent<Text>().text = soldier.ToString();
        GameObject.Find("AmountPro").GetComponent<Text>().text = protein.ToString();
    }

	public void FirstUpOx()
    {
        if(firstvalueOx >= 0 && firstvalueOx <= 9)
            firstvalueOx += 1;
        if(firstvalueOx > 9)
            firstvalueOx = 0;
        GameObject.Find("FirstNumberOx").GetComponent<Text>().text = firstvalueOx.ToString();
        tempOx = oxygen - (firstvalueOx * 10 + secondvalueOx);
        if (tempOx < 0)
            tempOx = 0;
        GameObject.Find("AmountOx").GetComponent<Text>().text = tempOx.ToString();
    }

    public void FirstDownOx()
    {
        if(firstvalueOx >= 0 && firstvalueOx <= 9)
            firstvalueOx -= 1;
        if(firstvalueOx < 0)
            firstvalueOx = 9;
        GameObject.Find("FirstNumberOx").GetComponent<Text>().text = firstvalueOx.ToString();
        tempOx = oxygen - (firstvalueOx * 10 + secondvalueOx);
        if (tempOx < 0)
            tempOx = 0;
        GameObject.Find("AmountOx").GetComponent<Text>().text = tempOx.ToString();
    }

    public void SecondUpOx()
    {
        if(secondvalueOx >= 0 && secondvalueOx <= 9)
            secondvalueOx += 1;
        if (secondvalueOx > 9)
            secondvalueOx = 0;
        GameObject.Find("SecondNumberOx").GetComponent<Text>().text = secondvalueOx.ToString();
        tempOx = oxygen - (firstvalueOx * 10 + secondvalueOx);
        if (tempOx < 0)
            tempOx = 0;
        GameObject.Find("AmountOx").GetComponent<Text>().text = tempOx.ToString();
    }

    public void SecondDownOx()
    {
        if(secondvalueOx >= 0 && secondvalueOx <= 9)
            secondvalueOx -= 1;
        if (secondvalueOx < 0)
            secondvalueOx = 9;
        GameObject.Find("SecondNumberOx").GetComponent<Text>().text = secondvalueOx.ToString();
        tempOx = oxygen - (firstvalueOx * 10 + secondvalueOx);
        if (tempOx < 0)
            tempOx = 0;
        GameObject.Find("AmountOx").GetComponent<Text>().text = tempOx.ToString();
    }

    public void FirstUpSol()
    {
        if (firstvalueSol >= 0 && firstvalueSol <= 9)
            firstvalueSol += 1;
        if (firstvalueSol > 9)
            firstvalueSol = 0;
        GameObject.Find("FirstNumberSol").GetComponent<Text>().text = firstvalueSol.ToString();
        tempSol = soldier - (firstvalueSol * 10 + secondvalueSol);
        if (tempSol < 0)
            tempSol = 0;
        GameObject.Find("AmountSol").GetComponent<Text>().text = tempSol.ToString();
    }

    public void FirstDownSol()
    {
        if (firstvalueSol >= 0 && firstvalueSol <= 9)
            firstvalueSol -= 1;
        if (firstvalueSol < 0)
            firstvalueSol = 9;
        GameObject.Find("FirstNumberSol").GetComponent<Text>().text = firstvalueSol.ToString();
        tempSol = soldier - (firstvalueSol * 10 + secondvalueSol);
        if (tempSol < 0)
            tempSol = 0;
        GameObject.Find("AmountSol").GetComponent<Text>().text = tempSol.ToString();
    }

    public void SecondUpSol()
    {
        if (secondvalueSol >= 0 && secondvalueSol <= 9)
            secondvalueSol += 1;
        if (secondvalueSol > 9)
            secondvalueSol = 0;
        GameObject.Find("SecondNumberSol").GetComponent<Text>().text = secondvalueSol.ToString();
        tempSol = soldier - (firstvalueSol * 10 + secondvalueSol);
        if (tempSol < 0)
            tempSol = 0;
        GameObject.Find("AmountSol").GetComponent<Text>().text = tempSol.ToString();
    }

    public void SecondDownSol()
    {
        if (secondvalueSol >= 0 && secondvalueSol <= 9)
            secondvalueSol -= 1;
        if (secondvalueSol < 0)
            secondvalueSol = 9;
        GameObject.Find("SecondNumberSol").GetComponent<Text>().text = secondvalueSol.ToString();
        tempSol = soldier - (firstvalueSol * 10 + secondvalueSol);
        if (tempSol < 0)
            tempSol = 0;
        GameObject.Find("AmountSol").GetComponent<Text>().text = tempSol.ToString();
    }

    public void FirstUpPro()
    {
        if (firstvaluePro >= 0 && firstvaluePro <= 9)
            firstvaluePro += 1;
        if (firstvaluePro > 9)
            firstvaluePro = 0;
        GameObject.Find("FirstNumberPro").GetComponent<Text>().text = firstvaluePro.ToString();
        tempPro = protein - (firstvaluePro * 10 + secondvaluePro);
        if (tempPro < 0)
            tempPro = 0;
        GameObject.Find("AmountPro").GetComponent<Text>().text = tempPro.ToString();
    }

    public void FirstDownPro()
    {
        if (firstvaluePro >= 0 && firstvaluePro <= 9)
            firstvaluePro -= 1;
        if (firstvaluePro < 0)
            firstvaluePro = 9;
        GameObject.Find("FirstNumberPro").GetComponent<Text>().text = firstvaluePro.ToString();
        tempPro = protein - (firstvaluePro * 10 + secondvaluePro);
        if (tempPro < 0)
            tempPro = 0;
        GameObject.Find("AmountPro").GetComponent<Text>().text = tempPro.ToString();
    }

    public void SecondUpPro()
    {
        if (secondvaluePro >= 0 && secondvaluePro <= 9)
            secondvaluePro += 1;
        if (secondvaluePro > 9)
            secondvaluePro = 0;
        GameObject.Find("SecondNumberPro").GetComponent<Text>().text = secondvaluePro.ToString();
        tempPro = protein - (firstvaluePro * 10 + secondvaluePro);
        if (tempPro < 0)
            tempPro = 0;
        GameObject.Find("AmountPro").GetComponent<Text>().text = tempPro.ToString();
    }

    public void SecondDownPro()
    {
        if (secondvaluePro >= 0 && secondvaluePro <= 9)
            secondvaluePro -= 1;
        if (secondvaluePro < 0)
            secondvaluePro = 9;
        GameObject.Find("SecondNumberPro").GetComponent<Text>().text = secondvaluePro.ToString();
        tempPro = protein - (firstvaluePro * 10 + secondvaluePro);
        if (tempPro < 0)
            tempPro = 0;
        GameObject.Find("AmountPro").GetComponent<Text>().text = tempPro.ToString();
    }
}
