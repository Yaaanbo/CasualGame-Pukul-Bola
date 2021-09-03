using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float batasAtas;
    public float batasBawah;
    public float speed;
    public string axis;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * speed * Time.deltaTime;
        //transform.Translate(0, move, 0);
        float nextPos = transform.position.y + move;
        if(nextPos > batasAtas)
        {
            move = 0;
        }
        if(nextPos < batasBawah)
        {
            move = 0;
        }
        transform.Translate(0, move, 0);
    }
}
