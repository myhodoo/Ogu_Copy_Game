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
        yield return new WaitForSecondsRealtime(0.01f); // ���������� ������� �ӵ��� ���ߴ� ��(0.01�� �� �� �������� ����)

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


        // ����� ���������� �����
        while(true)
        {

            yield return null;

            // �����ڵ�
            yield return new WaitForSecondsRealtime(2f); //���������� �ٴڿ� ��Ƽ� �����Ǵ� �ð�

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
