using System.Collections;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    
    public PlayerMove targetpos;
    public float MoveSpeed = 0.3f;
    public GameObject cursor;
    public float time = 0;


    void Start()
    {
        targetpos = GameObject.FindAnyObjectByType<PlayerMove>();
        StartCoroutine( time_increase() );

        StartCoroutine(CursorFollow_Coroutine());
    }


    bool m_ISFollow = false;
    IEnumerator time_increase()
    {
        m_ISFollow = true;
        yield return new WaitForSecondsRealtime(0.01f); // 낙하지점이 따라오는 속도와 멈추는 값(0.01초 후 그 지점에서 낙하)

        m_ISFollow = false;


        //while (true)
        //{
        //    time++;
        //    yield return new WaitForSecondsRealtime(1f);    
        //}
        
    }

    IEnumerator CursorFollow_Coroutine()
    {
        cursor.SetActive(true);

        while (m_ISFollow)
        {
            cursor.transform.position = Vector2.MoveTowards(cursor.transform.position, targetpos.transform.position, MoveSpeed * Time.deltaTime);

            yield return null;
        }


        // 돌덩어리 떨어지도록 만들기
        while(true)
        {

            yield return null;

            // 예제코드
            yield return new WaitForSecondsRealtime(2f); //낙하지점이 바닥에 닿아서 유지되는 시간

            if (true)
            {
                break;
            }
        }

        //yield return new WaitForSecondsRealtime(2.5f);
        cursor.SetActive(false);

        yield return new WaitForSecondsRealtime(1f);
        GameObject.Destroy(gameObject);
    }

    //void CursorFollow()
    //{
    //    cursor.SetActive(false);
    //    cursor.transform.position = Vector2.MoveTowards(cursor.transform.position, targetpos.transform.position, MoveSpeed * Time.deltaTime);
        

    //    if(time % 3 == 0)
    //    {
    //        cursor.SetActive(true);
    //        cursor.transform.position = targetpos.transform.position;
    //    }
    //}

    //void Update()
    //{
    //    CursorFollow();

    //}
}
