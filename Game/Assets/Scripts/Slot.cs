using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {

    public static GameObject windowOx, windowSol, windowPro;

    public GameObject item {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    void Start()
    {
        windowOx = GameObject.Find("WindowSystemOx");
        windowSol = GameObject.Find("WindowSystemSol");
        windowPro = GameObject.Find("WindowSystemPro");
    }

    #region IDropHandler implementation
    public void OnDrop (PointerEventData eventData)
    {
        if(!item)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
            if (GameObject.Find("O2").transform.parent != GameObject.Find("OxygenPut").transform && GameObject.Find("O2").transform.parent != GameObject.Find("OxygenTake").transform)
            {
                DragHandler.itemBeingDragged.transform.SetParent(DragHandler.startParent);
            }
            if (GameObject.Find("Soldier").transform.parent != GameObject.Find("SoldierPut").transform && GameObject.Find("Soldier").transform.parent != GameObject.Find("SoldierTake").transform)
            {
                DragHandler.itemBeingDragged.transform.SetParent(DragHandler.startParent);
            }
            if (GameObject.Find("Protein").transform.parent != GameObject.Find("ProteinPut").transform && GameObject.Find("Protein").transform.parent != GameObject.Find("ProteinTake").transform)
            {
                DragHandler.itemBeingDragged.transform.SetParent(DragHandler.startParent);
            }
            if (DragHandler.itemBeingDragged.transform.parent != DragHandler.startParent)
            {
                if (DragHandler.itemBeingDragged.name == "O2")
                {
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("OxygenPut").transform)
                    {
                        if((WindowSystem.firstvalueOx * 10 + WindowSystem.secondvalueOx) <= WindowSystem.oxygen)
                        {
                            GameObject.Find("TextOxygen").GetComponent<Text>().text = (WindowSystem.firstvalueOx * 10 + WindowSystem.secondvalueOx).ToString();
                            windowOx.SetActive(false);
                        }
                        else
                        {
                            GameObject.Find("TextOxygen").GetComponent<Text>().text = WindowSystem.oxygen.ToString();
                        }
                    }
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("OxygenTake").transform)
                    {
                        GameObject.Find("TextOxygen").GetComponent<Text>().text = null;
                        windowOx.SetActive(true);
                    }
                }
                if (DragHandler.itemBeingDragged.name == "Soldier")
                {
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("SoldierPut").transform)
                    {
                        if ((WindowSystem.firstvalueSol * 10 + WindowSystem.secondvalueSol) <= WindowSystem.soldier)
                        {
                            GameObject.Find("TextSoldier").GetComponent<Text>().text = (WindowSystem.firstvalueSol * 10 + WindowSystem.secondvalueSol).ToString();
                            windowSol.SetActive(false);
                        }
                        else
                        {
                            GameObject.Find("TextSoldier").GetComponent<Text>().text = WindowSystem.soldier.ToString();
                        }
                    }
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("SoldierTake").transform)
                    {
                        GameObject.Find("TextSoldier").GetComponent<Text>().text = null;
                        windowSol.SetActive(true);
                    }
                }
                if (DragHandler.itemBeingDragged.name == "Protein")
                {
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("ProteinPut").transform)
                    {
                        if ((WindowSystem.firstvaluePro * 10 + WindowSystem.secondvaluePro) <= WindowSystem.protein)
                        {
                            GameObject.Find("TextProtein").GetComponent<Text>().text = (WindowSystem.firstvaluePro * 10 + WindowSystem.secondvaluePro).ToString();
                            windowPro.SetActive(false);
                        }
                        else
                        {
                            GameObject.Find("TextProtein").GetComponent<Text>().text = WindowSystem.protein.ToString();
                        }
                    }
                    if (DragHandler.itemBeingDragged.transform.parent == GameObject.Find("ProteinTake").transform)
                    {
                        GameObject.Find("TextProtein").GetComponent<Text>().text = null;
                        windowPro.SetActive(true);
                    }
                }
            }
        }
    }
    #endregion
}
