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
    public float PercentHealth = 100f;
    private float PercentShield = 100f;
    private RectTransform DmgBar;
    private RectTransform Break;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject ShieldBar;
    [SerializeField] private GameObject BreakBar;

    [SerializeField] private int ShieldTimerinFrames = 150000;
    [SerializeField] private float ShieldTimerinSec = 3f;
    private bool IsShieldRecover = true;
    private int count;

    // Use this for initialization
    void Start () {
        DmgBar = GetComponent<RectTransform>();
        TotalHealth = HealthBar.GetComponent<RectTransform>().rect.width;

        Break = BreakBar.GetComponent<RectTransform>();
        TotalShield = ShieldBar.GetComponent<RectTransform>().rect.width;

        UpdateHealthBar();
    }
	
	// Update is called once per frame
	void Update () {
        //Counting a Timer in Seconds
        //ShieldTimerCount();
        //if (IsShieldRecover)
        //{
        //    ShieldRecover();
        //}


        //Counting a Timer in Frames
        //count += 1;
        //if (count >= ShieldTimerinFrames)
        //        count = 0;

    }

    //void ShieldTimerCount()
    //{
    //    if (ShieldRecover)
    //    {
    //        StartCoroutine("ShieldTimer");
    //    }
    //}

    public void Damage ( int dmg )
    {
        //If Shield is Down take Damage
        if (PercentShield <= 0)
        {
            PercentHealth -= dmg;
        }

        //Otherwise Damage Shield
        else
        {
            PercentShield -= dmg;
            print(PercentShield);
            IsShieldRecover = false;
            StartCoroutine("DamageTimer");
        }

        UpdateHealthBar();
    }

    IEnumerator DamageTimer()
    {
        Debug.Log("Timer Start");
        yield return new WaitForSeconds(ShieldTimerinSec);
        Debug.Log("Timer End");
        IsShieldRecover = true;
        ShieldRecover();

    }

    private void ShieldRecover()
    {
        PercentShield = 100;
        UpdateHealthBar();
    }

    private void UpdateHealthBar ()
    {
        CurrentHealth = PercentHealth / 100 * TotalHealth;
        CurrentShield = PercentShield / 100 * TotalShield;
        DmgBar.offsetMin = new Vector2(CurrentHealth, DmgBar.offsetMin.y);
        if (CurrentShield >= 0)
        {
            Break.offsetMin = new Vector2(CurrentShield, Break.offsetMin.y);
        }
    }
}
