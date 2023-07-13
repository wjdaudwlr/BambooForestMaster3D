using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector3 direction;

    private bool RandomSpeed = false;

    private void Start()
    {
        Invoke("Destroy", 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (RandomSpeed ? Random.Range(moveSpeed, moveSpeed + 0.1f) : moveSpeed) * Time.deltaTime);
    }

    public void Shoot(Vector3 dir, bool randomSpeed = false)
    {
        direction = dir.normalized;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        // LookRotation : �ش� ���� ������ �ٶ󺸴� ȸ�� ���¸� ��ȯ�Ѵ�.

        RandomSpeed = randomSpeed;
    }


    private void Destroy()
    {
        ObjectPool.ReturnObject(this);
    }
}
