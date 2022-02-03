using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;
    // Start is called before the first frame update
    Weapon sword;
    float attackDelay;
    bool isAttackReady;
    bool isStun = false;

    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //LookAround();
        //Move();
    }

    public void Move(Vector2 inputDirection)
    {

        // 이동 방향키 입력 값 가져오기
        Vector2 moveInput = inputDirection;
        bool isMove = moveInput.magnitude != 0;

        animator.SetBool("isRun", isMove);
        if (isMove)
        {
            // 카메라가 바라보는 방향
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            // 카메라의 오른쪽 방향
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            // 이동 방향
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            if (isStun)
            {
                moveInput = Vector2.zero;
            }


            characterBody.forward = moveDir;

     

            // 이동
            transform.position += moveDir * Time.deltaTime * 0.5f;
        }
    }



    private void LookAround()
    {
        // 마우스 이동 값 검출
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // 카메라의 원래 각도를 오일러 각으로 저장
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        // 카메라의 피치 값 계산
        float x = camAngle.x - mouseDelta.y;

        // 카메라 피치 값을 위쪽으로 70도 아래쪽으로 25도 이상 움직이지 못하게 제한
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        // 카메라 암 회전 시키기
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "wall")
        {
            Debug.Log("충돌 감지");
        }
    }
}
