using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatisticsChecker : MonoBehaviour
{
    public Dictionary<string, int> stat = new Dictionary<string, int>();

    [SerializeField] private Text TextPhysiological;
    [SerializeField] private Text TextSafety;
    [SerializeField] private Text TextBelonging;
    [SerializeField] private Text TextSelfEsteem;
    [SerializeField] private Text TextSelfActualization;
    
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
        TextPhysiological.text      = "Physiological: " +       stat["Physiological"].ToString();
        TextSafety.text             = "Safety: " +              stat["Safety"].ToString();
        TextBelonging.text          = "Belonging: " +           stat["Belonging"].ToString();
        TextSelfEsteem.text         = "Self Esteem: " +         stat["SelfEsteem"].ToString();
        TextSelfActualization.text  = "Self Actualization: " +  stat["SelfActualization"].ToString();
    }
}
