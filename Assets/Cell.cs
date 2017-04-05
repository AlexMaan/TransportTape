using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    void Awake () {
        //if (Mathf.Repeat(GoodsMixer.genGoodCount, 2) > 0) // pattern maker
            Instantiate(GoodsMixer.activeGood, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        GoodsMixer.genGoodCount++;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Destroyer")) Destroy(gameObject);
    }
}
