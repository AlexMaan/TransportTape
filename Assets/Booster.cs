using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

    public GameObject bombPrefab;
    public GameObject pausePrefab;
    public GameObject floorPrefab;
    public static int numberOfGoodsSelected;

    public void LaunchBoostEffect(int effectN, Vector3 effectPos, int collectedGoods) {
        numberOfGoodsSelected = collectedGoods;
        if (collectedGoods > 2) {
            switch (effectN) {
                case 1: StartCoroutine(BombIt(effectPos));
                    break;
                case 0: ReshapeIt(); 
                    break;
                case 2: PauseIt();
                    break;
                case 3: FloorIt();
                    break;
                //case 3: goto case 0;
                //case 4: goto case 6;                
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
        Instantiate(pausePrefab);
        TapeManager tapeManager = FindObjectOfType<TapeManager>();
        tapeManager.StopCoroutine("PauseTape");
        tapeManager.StartCoroutine("PauseTape");
    }

    void ReshapeIt() {
        FindObjectOfType<Reshaper>().ReshapeGoods(ClickPicker.active);
    }

    void FloorIt() {
        Instantiate(floorPrefab);
    }
}
