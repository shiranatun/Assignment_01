using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int targetScore = 1000;      
    public CoinSpawner coinSpawner;    

    static string CoinTag = "Coin";
    static string EnemyTag = "Enemy";

    Vector2 movement = Vector2.zero;
    private int totalScore = 0;
    private int numOfCoins = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        movement = Vector2.zero;

        var wValue = Keyboard.current.wKey.value;
        var sValue = Keyboard.current.sKey.value;
        var aValue = Keyboard.current.aKey.value;
        var dValue = Keyboard.current.dKey.value;

        movement += dValue * Vector2.right;
        movement += aValue * Vector2.left;
        movement += wValue * Vector2.up;
        movement += sValue * Vector2.down;
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CoinTag))
        {
            Coin collectedCoin = other.GetComponent<Coin>();

            if (collectedCoin != null)
            {
                totalScore += collectedCoin.coinValue;
                numOfCoins++;
                Destroy(other.gameObject);
                Debug.Log($"Coin: {collectedCoin.coinValue} | Score: {totalScore}");

                if (totalScore >= targetScore)
                {
                    Debug.Log("you won");
                    EditorApplication.isPlaying = false;
                }
                else if (numOfCoins % 5 == 0)
                {
                    coinSpawner.SpawnCoins();
                }
            }
        }
        else if (other.CompareTag(EnemyTag))
        {
            Debug.Log("you lose");
            EditorApplication.isPlaying = false;
        }
    }
}



