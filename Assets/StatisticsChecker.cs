using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatisticsChecker : MonoBehaviour
{
    public Dictionary<string, int> stat = new Dictionary<string, int>();

    [SerializeField] private Slider SliderPhysiological;
    [SerializeField] private Slider SliderSafety;
    [SerializeField] private Slider SliderBelonging;
    [SerializeField] private Slider SliderSelfEsteem;
    [SerializeField] private Slider SliderSelfActualization;
    void Start()
    {
        stat["Physiological"]         = 0;
        stat["Safety"]                = 0;
        stat["Belonging"]             = 0;
        stat["SelfEsteem"]            = 0;
        stat["SelfActualization"]     = 0;
    }

    void Update()
    {
        SliderPhysiological.value       = stat["Physiological"];
        SliderSafety.value              = stat["Safety"];
        SliderBelonging.value           = stat["Belonging"];
        SliderSelfEsteem.value          = stat["SelfEsteem"];
        SliderSelfActualization.value   = stat["SelfActualization"];
    }
}
