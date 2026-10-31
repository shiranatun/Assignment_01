using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    public Color coinColor = Color.white;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = coinColor;
    }
}
