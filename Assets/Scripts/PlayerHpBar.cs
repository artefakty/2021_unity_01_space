using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Image HpBar;

    private ShipPlayer shipPlayer;

    void Start()
    {
        shipPlayer = FindObjectOfType<ShipPlayer>();
    }

    void Update()
    {
        HpBar.fillAmount = Mathf.Clamp01(shipPlayer.HpLeft);
    }
}
