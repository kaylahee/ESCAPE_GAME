using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 걷기 속도
    [SerializeField]
    private float walkSpeed;

    // 카메라 민감도
    [SerializeField]
    private float lookSensitivity;

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    // 필요한 컴포넌트
    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    bool isBorder;
   
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CharacterRotation();
        CameraRotation();
        /*ChangeCam();*/
    }

    // 움직임
    private void Move()
    {
        // x가 좌우 // Horizantal : 키보드 화살표 좌우나 A,D
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        // z가 상하 // y는 점프
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        // Vector3 = (1, 0, 0) ->  _moveDirX 를 곱하여 좌우 방향
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        // _moveDirZ 를 곱하여 상하 방향
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        // Time.deltaTime : 1초동안 이만큼 움직이게 하게끔 하는 것
        // 이것이 없으면 플레이어는 순간이동하게 될 것
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        if(isBorder)
        {
            transform.position += new Vector3(_moveDirX, 0, _moveDirZ) * walkSpeed;
        }
    }

    // 좌우 캐릭터 회전
    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _charaterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_charaterRotationY));
    }

    // 상하 카메라 회전
    private void CameraRotation()
    {
        float _XRoation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _XRoation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    // 벽 통과 X
    private void StopToWall()
    {
        isBorder = Physics.Raycast(transform.position, transform.forward, 2, LayerMask.GetMask("House"));
    }

    /*public void ChangeCam()
    {
        if (bA.cam.depth > theCamera.depth)
        {
            theCamera.depth = 3;
        }
    }*/
}
