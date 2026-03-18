using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = GameObject.FindWithTag("Player").transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            respawnPoint = transform.position;
        }
    }
}