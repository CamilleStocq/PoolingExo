using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target;
    Pool<CreatureBehviour> pool;

    void Start()
    {
        pool = new(gameObject, prefab, 10);
        StartCoroutine(SpawnPoint());
    }

    private IEnumerator SpawnPoint()
    {
        while (true) // boucle infinie
        {
            yield return new WaitForSeconds(cooldown);
            CreatureBehviour creature = pool.Get();
            creature.sp = this;
            creature.GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }

    public void Teleport(CreatureBehviour creature)
    {
        pool.Add(creature);
    }
}
