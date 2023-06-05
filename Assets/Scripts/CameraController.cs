using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    [SerializeField] private float padding; // ��� ��ġ ���� �����̱� �����Ұ������� ���� ���� �� 

    private Vector3 moveDir;
    private float zoomScroll;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        Move(moveDir);
        Zoom(zoomScroll);
    }


    //ī�޶� ������
    // �׳� ī�޶� �������� ���Ʒ��� �����̸� ī�޶� �̻��ϰ� ������ �� �ִ�.
    // �׷��� ���带 �������� �������ش�.
    private void Move(Vector3 dir)
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }

    //ī�޶� ��
    private void Zoom(float scale)
    {
        //���� ī�޶� �̵�
        Camera.main.transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
    }


    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        //-padding �� ���콺�� ���� ȭ�� �Ѿ����
        //�ȿ����̰� �Ϸ�����

        if (-padding <= mousePos.x && mousePos.x <= padding) // ����
            moveDir.x = -1;
        else if (Screen.width - padding <= mousePos.x && mousePos.x <= Screen.width + padding) // ����
            moveDir.x = 1;
        else // �Ѵپƴϸ� �ȿ�����
            moveDir.x = 0;

        if (-padding <= mousePos.y && mousePos.y <= padding) // �Ʒ���

            moveDir.z = -1;
        else if (Screen.height - padding <= mousePos.y && mousePos.y <= Screen.height + padding)//����
            moveDir.z = 1;
        else// �ȿ�����
            moveDir.z = 0;
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y; //���Ʒ��� ��ũ�Ѹ� ����.
    }
}
