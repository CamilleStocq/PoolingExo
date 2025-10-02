using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
where T : IPoolClient // le type de T doit avoir implementer IPoolClint
{
    private GameObject anchor;
    private GameObject prefab;
    private Queue<T> queue = new();

    public Pool(GameObject anchor, GameObject prefab, int n)
    {
        this.anchor = anchor;
        this.prefab = prefab;

        for (int _ = 0; _ < n; _++)
        {
            GameObject go = GameObject.Instantiate(prefab);
            if (go.TryGetComponent(out T client))
            {
                Add(client);
            }
            else
            {
                throw new ArgumentException("Prefab doesn't have a IPoolClient component");
            }
        }
    }

    public void Add(T client)
    {
        queue.Enqueue(client);
        client.fall();
    }

    public T Get()
    {
        T client = queue.Dequeue();
        client.Arise(anchor.transform.position, anchor.transform.rotation);
        return client;
    }
}