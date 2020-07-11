using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour {
    private WeaponScriptEnnemis weapon;

    void Awake()
    {
        // Récupération de l'arme au démarrage
        weapon = GetComponent<WeaponScriptEnnemis>();
    }

    void Update()
    {
        // Tir auto
        if (weapon != null && weapon.CanAttack1)
        {
            weapon.Attack1(true);
        }
    }
}
