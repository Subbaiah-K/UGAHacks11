using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.gameObject != null)
        {
            Destroy(other.gameObject);
            return; // STOP the script here
        }
    }
}