using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraRotate
    : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private Transform camPos;

    [SerializeField]
    private float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�

    private float xRotate = 0.0f;   // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = camPos.transform.position;

        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        playerController.transform.eulerAngles = new Vector3(0, yRotate, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            yRotate += 180f;
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }
}
