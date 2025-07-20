using System.Collections;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class TargetFollow : MonoBehaviour
{

    [Header("[����׸��]")]
    public bool ISDebugMode = true;

    public PlayerMove targetpos;
    public float MoveSpeed = 0.3f;
    public GameObject cursor;
    public float time = 0;



    public GameObject hitpunch;
    public float DownSpeed = 1f;
    public LayerMask PlayerHitMask;


    void Start()
    {
        targetpos = GameObject.FindAnyObjectByType<PlayerMove>();
        StartCoroutine( time_increase() );

        StartCoroutine(CursorFollow_Coroutine());
        float zpunch = hitpunch.transform.position.z;
        zpunch = -3.0f;
        hitpunch.transform.position = new Vector3(hitpunch.transform.position.x, hitpunch.transform.position.y, zpunch);

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

    public Image lifeheart = null;

    [SerializeField]
    GameObject hitpunchclone = null;

    IEnumerator CursorFollow_Coroutine()
    {

        cursor.SetActive(true);

        while (m_ISFollow)
        {
            cursor.transform.position = Vector2.MoveTowards(cursor.transform.position, targetpos.transform.position, MoveSpeed * Time.deltaTime);

            yield return null;
        }


        if (ISDebugMode)
            yield break;



        // ����� ���������� �����
        hitpunchclone = GameObject.Instantiate(hitpunch);
        hitpunchclone.gameObject.SetActive(true);

        Vector3 temppos = transform.position;
        temppos.y += 4f;
        hitpunchclone.transform.position = temppos;


        if (hitpunchclone.transform.position.x < 0)
        {
            hitpunch.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (hitpunchclone.transform.position.x > 0)
        {
            hitpunch.GetComponent<SpriteRenderer>().flipX = false;
        }

        // ���������� �ϱ�
        while (true)
        {
           
            hitpunchclone.transform.Translate(0f, DownSpeed * Time.deltaTime, 0f);
            yield return null;

            if( this.transform.position.y >= hitpunchclone.transform.position.y )
            {
                break;
            }
        }


        BoxCollider2D boxcol = GetComponent<BoxCollider2D>();
        float reducewidth = 0.16f;

        
        // �浹����
        Collider2D hitcol = Physics2D.OverlapBox(this.transform.position, boxcol.size, 0f, PlayerHitMask);
        if (hitcol != null && ISDebugMode == false)
        {
            Debug.Log("�÷��̾� ������ ��");

            RectTransform rectTransform = lifeheart.GetComponent<RectTransform>();
            Vector2 size = rectTransform.sizeDelta;

            size.x = Mathf.Max(0, size.x - reducewidth );
            rectTransform.sizeDelta = size;

            //lifeheart.GetComponent<SpriteRenderer>().size -= 0.16f;          
        }


        //yield return new WaitForSecondsRealtime(2.5f);
        //cursor.SetActive(false);
        cursor.GetComponent<SpriteRenderer>().enabled = false;

        //yield return new WaitForSecondsRealtime(1f);
        yield return new WaitForSeconds(1f);

        GameObject.Destroy(hitpunchclone.gameObject );
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
