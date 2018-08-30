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
    private float TotalShield;
    private float CurrentHealth;
    private float CurrentShield;
    public float PercentHealth = 100;
    private float PercentShield = 100;
    private RectTransform DmgBar;
    private RectTransform Break;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject ShieldBar;
    [SerializeField] private GameObject BreakBar;

    public int ShieldTimerinFrames = 300;
    private int count;

    // Use this for initialization
    void Start () {
        DmgBar = GetComponent<RectTransform>();
        TotalHealth = HealthBar.GetComponent<RectTransform>().rect.width;

        Break = BreakBar.GetComponent<RectTransform>();
        TotalShield = ShieldBar.GetComponent<RectTransform>().rect.width;
    }
	
	// Update is called once per frame
	void Update () {
        count += 1;
        if (count >= ShieldTimerinFrames)
        {
            PercentShield = 100;
        }
        CurrentHealth = PercentHealth / 100 * TotalHealth;
        CurrentShield = PercentShield / 100 * TotalShield;
        DmgBar.offsetMin = new Vector2(CurrentHealth, DmgBar.offsetMin.y);
        Break.offsetMin = new Vector2(CurrentShield, Break.offsetMin.y);
    }

    public void Damage ( int dmg )
    {
        PercentShield -= dmg;
        print(PercentShield);
        if (PercentShield <= 0)
        {
            PercentHealth -= dmg;
        }
    }
}
