using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    [SerializeField] private float padding; // 어느 위치 부터 움직이기 시작할것인지에 대한 간격 값 

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


    //카메라 움직임
    // 그냥 카메라를 기준으로 위아래로 움직이면 카메라가 이상하게 움직일 수 있다.
    // 그래서 월드를 기준으로 움직여준다.
    private void Move(Vector3 dir)
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }

    //카메라 줌
    private void Zoom(float scale)
    {
        //메인 카메라 이동
        Camera.main.transform.Translate(Vector3.forward * zoomScroll * zoomSpeed * Time.deltaTime, Space.Self);
    }


    private void OnPointer(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();

        //-padding 은 마우스가 게임 화면 넘어갔을때
        //안움직이게 하려고함

        if (-padding <= mousePos.x && mousePos.x <= padding) // 좌측
            moveDir.x = -1;
        else if (Screen.width - padding <= mousePos.x && mousePos.x <= Screen.width + padding) // 우측
            moveDir.x = 1;
        else // 둘다아니면 안움직임
            moveDir.x = 0;

        if (-padding <= mousePos.y && mousePos.y <= padding) // 아래쪽

            moveDir.z = -1;
        else if (Screen.height - padding <= mousePos.y && mousePos.y <= Screen.height + padding)//위쪽
            moveDir.z = 1;
        else// 안움직임
            moveDir.z = 0;
    }

    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y; //위아래의 스크롤만 쓴다.
    }
}
