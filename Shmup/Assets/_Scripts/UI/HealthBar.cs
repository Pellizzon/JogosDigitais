using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    GameManager gm;
    void Awake()
    {
        bar = transform.Find("Bar");
        gm = GameManager.GetInstance();
    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f, 1f);
    }

    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
