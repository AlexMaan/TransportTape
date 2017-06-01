using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoost : MonoBehaviour {

    public List<GoodParam> effectedGoods = new List<GoodParam>();
    public List<BlockBox> effectedBoxes = new List<BlockBox>();
    float pressStapm;
    public float pressTime;
    public GameObject bombEffect;

    void Awake() {
        GetComponent<CircleCollider2D>().radius = Booster.numberOfGoodsSelected - 1;
        //GetComponentInChildren<SpriteRenderer>().gameObject.transform.localScale *= 2;
        GetComponent<Animator>().SetTrigger("appear");
        bombEffect.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D goodCollider) {
        effectedGoods.Add(goodCollider.GetComponent<GoodParam>());
        effectedBoxes.Add(goodCollider.GetComponent<BlockBox>());
    }

    void OnMouseDrag() {
        if(pressStapm == 0) GetComponent<Animator>().SetTrigger("grow");
        pressStapm += Time.deltaTime;        
        if (pressStapm > pressTime) ExplodeBomb();
    }
    void OnMouseUp() {
        pressStapm = 0;
        GetComponent<Animator>().SetTrigger("grow_stop");
    }

    void ExplodeBomb() {
        bombEffect.SetActive(true);
        bombEffect.transform.parent = transform.parent;
        pressStapm = 0;        
        foreach(GoodParam good in effectedGoods) {
            if (good != null) { ProgressWheel.levelProgress += 0.5f; good.GetComponent<Animator>().SetTrigger("collect"); Destroy(good.gameObject, 0.4f); }
        }
        foreach (BlockBox box in effectedBoxes) {
            if (box != null)  Destroy(box.gameObject, 0.1f);
        }
        Destroy(gameObject);
    }
}
