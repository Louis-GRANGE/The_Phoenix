using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public int Worms = 0;
    public int PioupiouScore = 3;
    public int life = 5;
    Rigidbody2D playerRB;
    Animator playerAnim;
    private AudioSource audioSource;
    public AudioClip HitSound;
    public Text ScoreWorms;
    public Text pioupiou;
    bool Domage = false;
    float time = 0f;
    float timer = 0f;
    public bool setlife = false;
    int lvl;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //PlayerPrefs.SetInt("PiouPiou", PioupiouScore);
    }

    public void AddWorms()
    {
        Worms++;
        ScoreWorms.text = Worms.ToString();
    }

    public void PiouPiou(int n)
    {
        PioupiouScore = n;
        pioupiou.text = PioupiouScore.ToString();
    }

    public void AddLife(int nb)
    {
        if(life < 4)
            life += nb;
    }
    public void RemoveLife(int nb)
    {
        life -= nb;
        Domage = true;
        playerAnim.SetBool("Domage", Domage);
        //if (!audioSource.isPlaying)
        //{
            audioSource.clip = HitSound;
            audioSource.Play();
        //}
    }
    private void Update()
    {
        pioupiou.text = PioupiouScore.ToString();
        if (setlife == true)
        {
            lvl = GameObject.Find("DifficultyMenu").GetComponent<Difficulties>().lvl;
            if (lvl == 0) life = 5;
            if (lvl == 1) life = 4;
            if (lvl == 2) life = 3;
            setlife = false;
        }
        if (life <= 0)
        {
            playerAnim.SetBool("IsAlive", false);
        }
        else
            playerAnim.SetBool("IsAlive", true);

        if (Domage == true && time < 0.5f)
        {
            time += Time.deltaTime;
        }
        if (Domage == true && time > 0.5f)
        {
            Domage = false;
            playerAnim.SetBool("Domage", Domage);
            time = 0f;
        }
        pioupiou.text = PioupiouScore.ToString();
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            playerRB.AddForce(new Vector3((knockbackDir.x) * -10, (knockbackDir.y) * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }
}
