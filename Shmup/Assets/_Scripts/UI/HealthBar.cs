using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f, 1f);
    }

    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
