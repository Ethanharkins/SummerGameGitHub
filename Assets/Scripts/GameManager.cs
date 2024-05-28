using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(playerPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
