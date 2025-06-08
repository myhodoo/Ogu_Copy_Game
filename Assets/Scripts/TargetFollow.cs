using System.Collections;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    
    public Transform targetpos;
    public float MoveSpeed = 0.3f;
    public GameObject cursor;
    public float time = 0;


    void Start()
    {
        
        StartCoroutine(time_increase());

    }

    IEnumerator time_increase()
    {
        while(true)
        {
            time++;
            yield return new WaitForSecondsRealtime(1f);    
        }
        
    }


    void CursorFollow()
    {
        cursor.SetActive(false);
        cursor.transform.position = Vector2.MoveTowards(cursor.transform.position, targetpos.position, MoveSpeed * Time.deltaTime);
        

        if(time % 3 == 0)
        {
            cursor.SetActive(true);
            cursor.transform.position = targetpos.position;
        }
    }

    void Update()
    {
        CursorFollow();

    }
}
