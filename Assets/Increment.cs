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
        Msg.text = gameObject.name + ": " + Count;

    }
}
