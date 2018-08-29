using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///*Left*/ rectTransform.offsetMin.x;
///*Right*/ rectTransform.offsetMax.x;
///*Top*/ rectTransform.offsetMax.y;
///*Bottom*/ rectTransform.offsetMin.y;


public class UIHealth : MonoBehaviour {

    private float TotalHealth;
    private float CurrentHealth;
    public float PercentHealth = 100;
    private RectTransform DmgBar;
    public GameObject HealthBar;

    // Use this for initialization
    void Start () {
        DmgBar = GetComponent<RectTransform>();
        TotalHealth = HealthBar.GetComponent<RectTransform>().rect.width;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentHealth = PercentHealth / 100 * TotalHealth;
        DmgBar.offsetMin = new Vector2(CurrentHealth, DmgBar.offsetMin.y);
    }
}
