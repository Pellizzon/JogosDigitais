
using System.Collections.Generic;
using UnityEngine;

//imagem usada: http://pixelartmaker.com/art/ece60cc31aeebda
//adaptado de: https://www.youtube.com/watch?v=FlyYbZZ803g&ab_channel=BluetailTeam
public class ScrollingBackground : MonoBehaviour
{
    public float Speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    private float heightCamera;
    private float widthCamera;

    private Vector3 PositionCam;
    private Camera cam;

    private void Awake()
    {
        //https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
        cam = Camera.main;
        heightCamera = 2f * cam.orthographicSize;
        widthCamera = heightCamera * cam.aspect;
    }

    void Update()
    {
        foreach (var item in sprites)
        {
            if (item.transform.position.y - item.bounds.size.y / 2 > cam.transform.position.y + heightCamera / 2)
            {
                SpriteRenderer sprite = sprites[0];
                foreach (var i in sprites)
                {
                    if (i.transform.position.y < sprite.transform.position.y)
                        sprite = i;
                }

                item.transform.position = new Vector2(sprite.transform.position.x, (sprite.transform.position.y - (sprite.bounds.size.y / 2) - (item.bounds.size.y / 2)));
            }

            item.transform.Translate(new Vector2(0, Time.deltaTime * Speed));
        }
    }
}

