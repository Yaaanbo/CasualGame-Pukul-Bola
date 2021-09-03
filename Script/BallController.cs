using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    public int xMin, xMaks;
    int scoreP1, scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;
    GameObject panelSelesai;
    Text txPemenang;
    AudioSource audio;
    public AudioClip hitsound;
    //public int xMin, xMaks;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float arahAwal = Random.Range(xMin, xMaks);
        Vector2 arah = new Vector2(arahAwal, 0);
        /*Vector2 arah = new Vector2(2, 0);*/
        rb.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        panelSelesai = GameObject.Find("Panel Selesai");
        panelSelesai.SetActive(false);
        //Audio
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D coll)
    {
        audio.PlayOneShot(hitsound);
        if(coll.gameObject.name == "Batas kanan")
        {
            
            Vector2 arah = new Vector2(2, 0).normalized;
            rb.AddForce(arah * force);
            scoreP1++;
            TampilkanScore();
            resetBall();
            if (scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player biru menang!";
                Destroy(gameObject);
                return;
            }
            
        }
        if (coll.gameObject.name == "Batas kiri")
        {
            
            Vector2 arah = new Vector2(-2, 0).normalized;
            rb.AddForce(arah * force);
            scoreP2++;
            TampilkanScore();
            resetBall();
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player merah menang!";
                Destroy(gameObject);
                return;
            }

        }
        if(coll.gameObject.name == "Pemukul 1" || coll.gameObject.name == "Pemukul 2")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force);
        }
    }
    void resetBall()
    {
        float ballRespawn = Random.Range(-4, 4);
        float velocityRespawn = Random.Range(-2, 2);
        transform.localPosition = new Vector2(0, ballRespawn);
        rb.velocity = new Vector2(0, velocityRespawn);
    }
    void TampilkanScore()
    {
        print($"Score P1 {scoreP1} Score P2 {scoreP2}");
        scoreUIP1.text = $"{scoreP1} ";
        scoreUIP2.text = $"{scoreP2} ";
    }

}