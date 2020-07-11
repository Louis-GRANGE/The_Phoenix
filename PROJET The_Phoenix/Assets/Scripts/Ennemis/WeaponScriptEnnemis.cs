using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptEnnemis : MonoBehaviour
{
    public Transform shotPrefab1;
    public float shootingRate1 = 0.25f;
    private float shootCooldown1;

    void Start()
    {
        shootCooldown1 = 0f;
    }

    void Update()
    {
        if (shootCooldown1 > 0)
        {
            shootCooldown1 -= Time.deltaTime;
        }
    }
    public void Attack1(bool isEnemy1)
    {
        if (CanAttack1)
        {
            shootCooldown1 = shootingRate1;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab1) as Transform;

            // Position
            shotTransform.position = transform.position;

            // Propriétés du script
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy1;
            }

            // On saisit la direction pour le mouvement
            MoveScriptBulletEnnemis move = shotTransform.gameObject.GetComponent<MoveScriptBulletEnnemis>();
            //PlayerController player = 

            if (move != null && position() == true)
                move.direction = -this.transform.right; // ici la droite sera le devant de notre objet
            else if (move != null && position() == false)
                move.direction = this.transform.right;

        }
    }
    public bool CanAttack1
    {
        get
        {
            return shootCooldown1 <= 0f;
        }
    }
    bool position()
    {
        Transform target;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameObject.transform.position.x < target.transform.position.x)
            return true; // A sa gauche
        else
            return false; // A sa droite
    }
}
