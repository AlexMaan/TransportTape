using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoost : MonoBehaviour {

    List<GoodParam> effectedGoods;
    float pressStapm;
    public float pressTime;

    void Awake() {
        GetComponent<CircleCollider2D>().radius = Booster.numberOfGoodsSelected - 1;
        GetComponentInChildren<SpriteRenderer>().gameObject.transform.localScale *= 0.1f + 0.3f * Booster.numberOfGoodsSelected;
    }

    void OnTriggerEnter2D(Collider2D goodCollider) {
        effectedGoods.Add(goodCollider.GetComponent<GoodParam>());
    }

    void OnMouseDrag() {
        pressStapm += Time.deltaTime;
        if (pressStapm > pressTime) ExplodeBomb();
    }

    void ExplodeBomb() {
        print("boom");
    }
}
