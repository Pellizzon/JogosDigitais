﻿using UnityEngine;

//Referência: https://www.youtube.com/watch?v=zit45k6CUMk&ab_channel=Dani

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > (startpos + length))
            startpos += length;
        else if (temp < (startpos - length))
            startpos -= length;
    }
}
