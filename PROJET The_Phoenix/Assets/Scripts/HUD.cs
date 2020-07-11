using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;
    public Image HeartUI;

    private PlayerInventory player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerInventory>();

    }

    void Update()
    {
        if (player.life >= 0)
            HeartUI.sprite = HeartSprites[player.life];
        if (player.life < 0)
            HeartUI.sprite = HeartSprites[0];
    }
}
