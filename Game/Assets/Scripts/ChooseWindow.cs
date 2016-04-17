using UnityEngine;
using System.Collections;

public class ChooseWindow : MonoBehaviour {

    private Vector3 mousePosition;
    private Vector3 mouseOffset;
    public static float moveSpeed = 1.0f;
    public static bool select1, select2, select3;
    public static GameObject leel, windowRed, windowWhite, windowPlasma, collider1, collider2, collider3, colResource1, colResource2, colResource3;

    void Start() {
        leel = GameObject.Find("CylinderWmouse");
        windowRed = GameObject.Find("CylinderR"); windowRed.SetActive(false);
        windowWhite = GameObject.Find("CylinderW"); windowWhite.SetActive(false);
        windowPlasma = GameObject.Find("CylinderP"); windowPlasma.SetActive(false);
        collider1 = GameObject.Find("CylinderCollider (1)");
        collider2 = GameObject.Find("CylinderCollider (2)");
        collider3 = GameObject.Find("CylinderCollider (3)");

        colResource1 = GameObject.Find("CylinderRmouse");
        colResource2 = GameObject.Find("CylinderWmouse");
        colResource3 = GameObject.Find("CylinderYmouse");
    }

    public void showWindow(int windowNum) {
        if (windowNum == 1) {
            windowRed.SetActive(true);
            windowPlasma.SetActive(false);
            windowWhite.SetActive(false);
        }
        else if (windowNum == 2) {
            windowWhite.SetActive(true);
            windowRed.SetActive(false);
            windowPlasma.SetActive(false);
        }
        else if (windowNum == 3) {
            windowPlasma.SetActive(true);
            windowRed.SetActive(false);
            windowWhite.SetActive(false);
        }
    }
}
