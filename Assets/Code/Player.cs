using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float speed; // 플레이어의 이동 속도
    public Vector2 inputVec; // 플레이어의 입력 방향
    public float inputDelay = 0.5f; // 입력 무시 시간 (필요에 따라 변경할 수 있습니다)
    public bool isdaed = false;
    private bool isMoving = false; // 플레이어가 이동 중인지 여부
    private float nextInputTime; // 다음 입력 시간
     float maxX = 4.0f; // Set the maximum allowed X position
     float minX = -4.0f; // Set the minimum allowed X position
     float maxY = 3.0f; // Set the maximum allowed Y position
     float minY = -5.0f; // Set the minimum allowed Y position

    SpriteRenderer spriter; // 플레이어의 스프라이트 렌더러
    Rigidbody2D rigid; // 플레이어의 Rigidbody2D
    Animator anim; // 플레이어의 애니메이터

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMoving && Time.time > nextInputTime && inputVec != Vector2.zero) // 입력 무시 시간 이후이고, 플레이어가 이동 중이 아니며, 입력이 있는 경우
        {
            StartCoroutine(Move()); // Move() 코루틴을 시작합니다
            nextInputTime = Time.time + inputDelay; // 다음 입력 시간은 현재 시간 + 입력 무시 시간입니다
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        //Vector2 startPos = rigid.position;
        //Vector2 inputVecNormalized = inputVec.normalized;



        //float targetX = Mathf.Clamp(startPos.x + 4, minX, maxX); //목표로 하는 위치가(이동된 위치가) 최소값보다 작으면 최소값으로 크면 max값으로
        //float targetY = Mathf.Clamp(startPos.y + 4, minY, maxY);


        //Vector2 endPos = new Vector2(Mathf.Round(targetX), Mathf.Round(targetY));

        //if (endPos == startPos)
        //{
        //    isMoving = false; // Cancel the movement
        //    yield break; // Exit the coroutine early
        //}

        //float t = 0; // 현재 이동 시간
        //while (t < 1) // 이동이 완료되지 않은 경우
        //{
        //    t += Time.deltaTime * speed; // 현재 이동 시간을 증가시킵니다
        //    rigid.position = Vector2.Lerp(startPos, endPos, t); // 플레이어의 위치를 이동합니다
        //    yield return null; // 다음 프레임을 기다립니다
        //}
        Vector2 inputVecNomalized = inputVec.normalized*4f;

        Debug.Log(inputVecNomalized);
        if (rigid.position.x + inputVecNomalized.x > maxX ||
        rigid.position.y + inputVecNomalized.y > maxY ||
        rigid.position.x + inputVecNomalized.x < minX || 
        rigid.position.y + inputVecNomalized.y  < minY)
        {
            isMoving = false; // Cancel the movement
            yield break; // Exit the coroutine early
        }



        float speed = 4.0f; // 이동 속도

        Vector2 targetPos = rigid.position;

        if (inputVecNomalized.x > 0)
        {
            targetPos.x += 4;
        }
        else if (inputVecNomalized.x == 0 && inputVecNomalized.y > 0)
        {
            targetPos.y += 4;
        }
        else if (inputVecNomalized.x ==0  && inputVecNomalized.y < 0)
        {
            targetPos.y -= 4;
        }
        else
        {
            targetPos.x -= 4;
        }

        float t = 0; // 현재 이동 시간
        while (t < 1) // 이동이 완료되지 않은 경우
        {
            t += Time.deltaTime * speed;
            rigid.position = Vector2.Lerp(rigid.position, targetPos, t);
            yield return null;
        }

        isMoving = false; // 플레이어가 이동 중으로 설정합니다
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>(); // 입력을 저장합니다
        Vector2 joystickInput = value.Get<Vector2>();

    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); // 애니메이터의 "Speed" 속성에 입력의 크기를 설정합니다

        if (inputVec.x != 0) // 입력의 x 성분이 0이 아닌 경우
        {
            spriter.flipX = inputVec.x < 0; // 스프라이트를 뒤집습니다
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster") // 충돌한 오브젝트의 태그가 "Monster"인 경우
        {
            anim.SetTrigger("Attack"); // 애니메이터의 "Attack" 트리거를 실행합니다
        }
    }
}