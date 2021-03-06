using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private float moveSpeed;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if (GameManager.Instance.gState != GameState.Run)
            return;

        Move();
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hAxis, 0, vAxis).normalized;

        rigid.velocity = transform.TransformDirection(dir.normalized) * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            gameController.GameOver();
            Debug.Log("GameOver");
        }
    }

}
