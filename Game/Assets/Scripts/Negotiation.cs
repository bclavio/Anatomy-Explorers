using UnityEngine;
using System.Collections;

public class Negotiation : MonoBehaviour {


    private Vector3 mousePosition;
    private Vector3 mouseOffset;
    public static Transform targetPool;
    public static float moveSpeed = 1.0f;
    public static bool select1, select2, select3, send;
    public static GameObject leel, oxPos, soPos, prPos, pool1, pool2, pool3, colResource1, colResource2, colResource3, mouse;

    void Start () {
	    leel = GameObject.Find("CylinderWmouse");
        oxPos = GameObject.Find("BoxCollider (1)");
        soPos = GameObject.Find("BoxCollider (2)");
        prPos = GameObject.Find("BoxCollider (3)");
        pool1 = GameObject.Find("CylinderCollider (1)"); 
        pool2 = GameObject.Find("CylinderCollider (2)"); 
        pool3 = GameObject.Find("CylinderCollider (3)");

        targetPool = GameObject.Find("CylinderCollider (3)").GetComponent<Transform>();

        colResource1 = GameObject.Find("CylinderRmouse");
        colResource2 = GameObject.Find("CylinderWmouse");
        colResource3 = GameObject.Find("CylinderYmouse");

        mouse = GameObject.Find("CylinderEmptymouse");


    }

    void Update() {

        if (Input.GetMouseButton(0)) { // mouse down
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            if (Input.GetMouseButton(0) && select1) {
                colResource1.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                colResource1.SetActive(true);
                colResource2.SetActive(false);
                colResource3.SetActive(false);
            }
            else if (Input.GetMouseButton(0) && select2) {
                colResource2.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                colResource2.SetActive(true);
                colResource1.SetActive(false);
                colResource3.SetActive(false);

            }
            else if (Input.GetMouseButton(0) && select3) {
                colResource3.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                colResource3.SetActive(true);
                colResource1.SetActive(false);
                colResource2.SetActive(false);

            }
        }
        if (Input.GetMouseButtonUp(0)) {
            if (select1 && !send || select2 && !send || select3 && !send) {
                colResource1.SetActive(false);
                colResource2.SetActive(false);
                colResource3.SetActive(false);
            }
            else if (select1 && send) {
                colResource1.transform.position = targetPool.position;
            }
            else if (select2 && send) {
                colResource2.transform.position = targetPool.position;
            }
            else if (select3 && send) {
                colResource3.transform.position = targetPool.position;
            }
        }
    }

    void OnCollisionEnter(Collision col) { 
        if (col.gameObject.tag == "Pool") {
            send = true;
        }
        else if (col.gameObject.tag == "Collider1") {
            select1 = true;
            select2 = false;
            select3 = false;
            send = false;
            colResource1.SetActive(true);
        }
        else if (col.gameObject.tag == "Collider2") {
            select2 = true;
            select3 = false;
            select1 = false;
            send = false;
            colResource2.SetActive(true);
        }
        else if (col.gameObject.tag == "Collider3") {
            select3 = true;
            select2 = false;
            select1 = false;
            send = false;
            colResource3.SetActive(true);
        }
    }
}
