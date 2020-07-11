using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    private float shootCooldown;
    PlayerController player;

    void Start()
    {
        shootCooldown = 0f;
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Position
            shotTransform.position = transform.position;

            // Propriétés du script
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // On saisit la direction pour le mouvement
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            //PlayerController player = 
            if (move != null)
                move.direction = this.transform.right; // ici la droite sera le devant de notre objet
            
            if (player.facingRight == true)
                move.direction = new Vector2(1, 0);
            else
                move.direction = new Vector2(-1, 0);
        }
    }
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

}
