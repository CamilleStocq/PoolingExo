using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject, 0.25f);

        if (other.TryGetComponent(out CreatureBehviour creature)) // instance que si c'est necessaire
        {
            creature.Teleport();
        }
    }
}