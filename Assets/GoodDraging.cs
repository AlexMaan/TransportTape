using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDraging : MonoBehaviour {

    public GameObject playManager;

    Vector3 dragOffset;
    public List<GameObject> placePoints;
    Vector3 nearestPos;


    private void Awake(){
        playManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnMouseDown() {
        dragOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
    }

    void OnMouseDrag() {
        StartCoroutine("Dragging");        
    }

    void OnMouseUp() {
        StopCoroutine("Dragging");
        //nearestPos = FindNearest().transform.position;
        //transform.position = nearestPos;
        //placePoints.Clear();
        //playManager.GetComponent<ClickPicker>().ClicksReset();
    }

    //GameObject FindNearest() {
    //    GameObject nearestPlace = gameObject;
    //    Vector3 nearestDistance = new Vector3(100, 100, 100);
    //    foreach (GameObject item in placePoints) {
    //        Vector3 distance = transform.position - item.transform.position;
    //        if (distance.sqrMagnitude < nearestDistance.sqrMagnitude) { nearestDistance = distance; nearestPlace = item; }
    //    }
    //    return nearestPlace;
    //}

    IEnumerator Dragging() {
        yield return new WaitForSeconds(0.1f);
        while (true) {
            Vector3 dragMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            transform.position = dragMousePos + dragOffset;

            yield return null;
        }
    }
    
}
