using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRepos : MonoBehaviour {

    public static bool autoRepOn;
    CellGoodReposition cellRepos;

    void Awake() {
        cellRepos = FindObjectOfType<CellGoodReposition>();
        autoRepOn = true;
    }

    void OnTriggerEnter2D(Collider2D goodCollider) {
        if (autoRepOn) StartCoroutine(ReposLaunch(goodCollider));
    }

    void OnTriggerExit2D(Collider2D goodCollider) {
        if (autoRepOn) StartCoroutine(ReposLaunch(goodCollider));
    }

    IEnumerator ReposLaunch(Collider2D goodCollider) {
        yield return new WaitForSeconds(Random.Range(0f, 0.5f));
        if (goodCollider.gameObject.tag == "Good")
            cellRepos.GoodReposition(goodCollider.GetComponent<GoodParam>());
    }
}
