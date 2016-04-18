using UnityEngine;
using System.Collections;

public class Negotiation : MonoBehaviour {


    private Vector3 mousePosition;
    private Vector3 mouseOffset;
    public static Transform targetPool, outScreen;
    public static float moveSpeed = 1.0f;
    public static bool select1, select2, select3, send, collision;
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
        outScreen = GameObject.Find("OuterScreen").GetComponent<Transform>(); 
        colResource1 = GameObject.Find("CylinderRmouse");
        colResource2 = GameObject.Find("CylinderWmouse");
        colResource3 = GameObject.Find("CylinderYmouse");

        mouse = GameObject.Find("CylinderEmptymouse");


    }

    void Update() {

        if (Input.GetMouseButton(0)) { // mouse down
            if (collision)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouse.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                if (Input.GetMouseButton(0) && ChooseWindow.getsWindowNumber == 1 && ChooseWindow.drag)
                {
                    colResource1.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                }
                else if (Input.GetMouseButton(0) && ChooseWindow.getsWindowNumber == 2 && ChooseWindow.drag)
                {
                    colResource2.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

                }
                else if (Input.GetMouseButton(0) && ChooseWindow.getsWindowNumber == 3 && ChooseWindow.drag)
                {
                    colResource3.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                }
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            if (mouse.transform.position != GameObject.Find("ButtonPool (3)").transform.position && mouse.transform.position != GameObject.Find("ButtonR").transform.position && mouse.transform.position != GameObject.Find("ButtonW").transform.position && mouse.transform.position != GameObject.Find("ButtonP").transform.position)
            {
                Debug.Log("Count me in");
                collision = false;
            }
            if(!send)
            {
                if (colResource1.activeInHierarchy)
                {
                    colResource1.transform.position = outScreen.position;
                }
                else if (colResource2.activeInHierarchy)
                {
                    colResource2.transform.position = outScreen.position;
                }
                else if (colResource3.activeInHierarchy)
                {
                    colResource3.transform.position = outScreen.position;
                }
            }
            else if ( send && ChooseWindow.getsWindowNumber == 1) {
                colResource1.transform.position = targetPool.position;
                //ChooseWindow.drag = false;
                //ChooseWindow.getsWindowNumber = 0;
            }
            else if ( send && ChooseWindow.getsWindowNumber == 2) {
                colResource2.transform.position = targetPool.position;
                //ChooseWindow.getsWindowNumber = 0;
            }
            else if ( send && ChooseWindow.getsWindowNumber == 3) {
                colResource3.transform.position = targetPool.position;
                //ChooseWindow.getsWindowNumber = 0;
            }
        }
    }

    void OnCollisionEnter(Collision col) { 
        if (col.gameObject.tag == "Pool") {
            send = true;
            mouse.transform.position = GameObject.Find("ButtonPool (3)").transform.position;
        }
        else if(col.gameObject.tag == "Collider1")
        {
            Debug.Log("I am in");
            ChooseWindow.drag = true;
            colResource1.SetActive(true);
            colResource2.SetActive(false);
            colResource3.SetActive(false);
            collision = true;
        }
        else if (col.gameObject.tag == "Collider2")
        {
            ChooseWindow.drag = true;
            colResource2.SetActive(true);
            colResource1.SetActive(false);
            colResource3.SetActive(false);
        }
        else if (col.gameObject.tag == "Collider3")
        {
            ChooseWindow.drag = true;
            colResource3.SetActive(true);
            colResource1.SetActive(false);
            colResource2.SetActive(false);
        }
        /*else if (col.gameObject.tag == "Collider1") {
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
        }*/
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Pool")
        {
            send = false;
        }
        else if(col.gameObject.tag == "Collider1")
        {
            ChooseWindow.drag = false;
        }
    }
}
