using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseCdBar : MonoBehaviour
{
    public Player Player;
    
    private Image cdBar;

    void Awake()
    {
        cdBar = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cdBar.fillAmount = 1 - Player.PlayerFire.GetReverseTimer();
    }
}
