using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public Image CDBar;
    public float CD;
    public float currentCD;
    // Start is called before the first frame update
    void Start()
    {
        CDBar = gameObject.GetComponent<Image>();
        currentCD = CD;
    }

    // Update is called once per frame
    void Update()
    {
        CDBar.fillAmount = currentCD / CD;
    }
}
