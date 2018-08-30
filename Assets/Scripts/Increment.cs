using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Increment : MonoBehaviour {
    public int Count;
    private Text Msg;
	// Use this for initialization
	void Start () {
        Msg = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Count <= 99) {
			Msg.text = Count.ToString ("D2");
		}
    }
}
