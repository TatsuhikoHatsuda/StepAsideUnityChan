using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {

    // unitychanのオブジェクト
    private GameObject unitychan;

	// Use this for initialization
	void Start () {
        // unitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
        // 画面外に出た場合このオブジェクトを破棄する
        if (this.transform.position.z < unitychan.transform.position.z - 8) {
            Destroy(this.gameObject);
        }
	}
}
