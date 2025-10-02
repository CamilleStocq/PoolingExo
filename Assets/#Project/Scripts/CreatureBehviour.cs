using UnityEngine;

public class CreatureBehviour : MonoBehaviour, IPoolClient
{
    public Spawn sp;
    public void Arise(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void fall()
    {
        gameObject.SetActive(false);
    }

    public void Teleport()
    {
        sp.Teleport(this);
    }
}