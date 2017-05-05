using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public GameObject bombPrefab;
    public static int numberOfGoodsSelected;

    public void LaunchBoostEffect(int effectN, Vector3 effectPos, int collectedGoods) {
        numberOfGoodsSelected = collectedGoods;
        if (collectedGoods > 2) {
            switch (effectN) {
                case 6: StartCoroutine(BombIt(effectPos));
                    break;
                case 0: PauseIt();
                    break;
                case 1: goto case 0;
                case 2: goto case 0;
                case 3: goto case 0;
                case 4: goto case 6;
                case 5: goto case 0;
                default:
                    break;
            }
        }
    }

    IEnumerator BombIt(Vector3 effectPos) {
        yield return new WaitForSeconds(0.4f);
        Instantiate(bombPrefab, effectPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Tape").transform);
    }

    void PauseIt() {
        print("pause");
    }
}
