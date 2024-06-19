using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillMeterController : MonoBehaviour
{
    public Image fillMeter;
    public float hungerFullAmount;
    public float hungerFillAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillMeter.fillAmount = (hungerFillAmount/hungerFullAmount);
    }
}
