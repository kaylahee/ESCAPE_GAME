using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ȱ� �ӵ�
    [SerializeField]
    private float walkSpeed;

    // ī�޶� �ΰ���
    [SerializeField]
    private float lookSensitivity;

    // ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    // �ʿ��� ������Ʈ
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

    // ������
    private void Move()
    {
        // x�� �¿� // Horizantal : Ű���� ȭ��ǥ �¿쳪 A,D
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        // z�� ���� // y�� ����
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        // Vector3 = (1, 0, 0) ->  _moveDirX �� ���Ͽ� �¿� ����
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        // _moveDirZ �� ���Ͽ� ���� ����
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        // Time.deltaTime : 1�ʵ��� �̸�ŭ �����̰� �ϰԲ� �ϴ� ��
        // �̰��� ������ �÷��̾�� �����̵��ϰ� �� ��
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        if(isBorder)
        {
            transform.position += new Vector3(_moveDirX, 0, _moveDirZ) * walkSpeed;
        }
    }

    // �¿� ĳ���� ȸ��
    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _charaterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_charaterRotationY));
    }

    // ���� ī�޶� ȸ��
    private void CameraRotation()
    {
        float _XRoation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _XRoation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    // �� ��� X
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
