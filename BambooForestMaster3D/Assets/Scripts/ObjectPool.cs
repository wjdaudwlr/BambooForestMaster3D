using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    private Queue<Arrow> poolingObjectQueue = new Queue<Arrow>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Initialize(10);
    }

    private Arrow CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Arrow>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static Arrow GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
        arrow.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(arrow);
    }
}
