using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public float destroyTime;

    void Awake() {
        Invoke("DestroyIt", destroyTime);
    }

    void OnTriggerEnter2D(Collider2D goodCollider) {
        if (goodCollider.GetComponent<GoodParam>() != null) StartCoroutine(Flooring(goodCollider));
    }

    IEnumerator Flooring(Collider2D goodCollider) {
        yield return new WaitForSeconds(0.5f);
        goodCollider.GetComponent<Animator>().SetTrigger("collect");
        Destroy(goodCollider.gameObject, 0.4f);
        ProgressWheel.levelProgress += ClickPicker.plusPoints * 0.05f;
    }

    void DestroyIt() {
        GetComponent<Animator>().SetTrigger("disappear");
        Destroy(gameObject, 0.5f);
    }
}
