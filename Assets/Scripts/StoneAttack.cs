using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoneAttack : MonoBehaviour
{
    //코르틴 사용해서 돌 포물선 그리면서 이동하는 것 처럼 만들기



    Rigidbody2D rb;
    void Start()
    {

        //GameObject.FindAnyObjectByType<>



        spriteRenderer = GetComponent<SpriteRenderer>();
        
        this.rb = GetComponent<Rigidbody2D>();

        originscale = transform.localScale;

    }
    public SpriteRenderer spriteRenderer;
    public Sprite ChangeStone;
    public Transform Stonehole;
    public float speed = 3f;


    //던지는 효과를 나타낼 때 scale을 커지고 작게 만들기
    //3.53f ~ 5.59f - scale , -0.32f - ypos

    private float size = 5.6f;
    public float upspeed;
    private Vector2 originscale;
    private float time;


    IEnumerator StoneThrowCoroutinue()
    {

        Vector3 temporizinsize = new Vector3(originscale.x, originscale.y, originscale.x);
        this.transform.localScale = temporizinsize;

        Vector3 divsize = new Vector3(upspeed, upspeed, upspeed);

        while (true)
        {
            // 현재 스케일에 스케일변경 값 적용
            Vector3 changesize = (divsize * Time.deltaTime) + this.transform.localScale;

            // 특정 스케일 이상이되면 유지
            if (changesize.x >= size)
            {
                changesize.x = size;
                changesize.y = size;
                changesize.z = size;
            }
            this.transform.localScale = changesize;

            // y축이 0이상이되면 while 종료
            if(transform.position.y >= 1f)
            {
                time = 0;
                break;
            }

            //if (transform.localScale.x >= size)
            //{
            //    time = 0;
            //    break;
            //}

            yield return null;
        }



        while (true)
        {

            //transform.localScale = -(originscale * (1f + time * upspeed));
            //time += Time.deltaTime;

            //if (transform.localScale.x <= 3.53f)
            //{
            //    time = 0f;
            //    break;
            //}
            //yield return null;


            // 현재 사이즈에서 무조건 점차적으로 작아지게 하기
            Vector3 changesize = this.transform.localScale - (divsize * Time.deltaTime);
            // 너무 작아지는것 특정크기로 유지
            if (changesize.x <= originscale.x)
            {
                changesize.x = originscale.x;
                changesize.y = originscale.y;
                changesize.z = originscale.x;

                break;
            }

            this.transform.localScale = changesize;


            yield return null;
        }

    }

    IEnumerator Up_Coroutine()
    {
        while (transform.localScale.x < size)
        {
            this.transform.localScale = originscale * (1f + time * upspeed);
            time += Time.deltaTime;

            if (transform.localScale.x >= size)
            {
                time = 0;
                break;
            }

            yield return null;
        }
    }

    IEnumerator Down_Coroutine()
    {
        while (transform.localScale.x >= size)
        {
            transform.localScale = -(originscale * (1f + time * upspeed));
            time += Time.deltaTime;

            if (transform.localScale.x <= 3.53f)
            {
                time = 0f;
                break;
            }
            yield return null;
        }
    }

    public bool m_ISAttack = false;
    public CreateStone createStone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"확인 : {collision.name}, {collision.tag}");
        if (collision.gameObject.tag == "potion")
        {
            spriteRenderer.sprite = ChangeStone;
            //this.gameObject.layer = 7;
            gameObject.tag = "StoneChange";
        }

        if (m_ISAttack)
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            if (collision.gameObject.tag == "knife")
            {
                //this.rb.isKinematic = false;

                this.GetComponent<Collider2D>().isTrigger = true;
                this.rb.velocity = Vector3.up * (speed + 2f);

                StartCoroutine(StoneThrowCoroutinue());

            }

            m_ISAttack = false;

        }

        if (collision.gameObject.tag == "Catapult")
        {
            // 복사된 stone도 Stonehole 위치에서 멈추기 -> 복사된 stone이 stonehole 값이 없음
            //GameObject clone = createStone.stoneNew();

            this.transform.position = new Vector3(Stonehole.position.x, Stonehole.position.y, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            m_ISAttack = true;
        }

        

        //if(collision.gameObject.tag == "Enemy")
        //{
        //    RectTransform rectTransform = EnemyFill.GetComponent<RectTransform>();
        //    Vector2 size = rectTransform.sizeDelta;
        //
        //    size.x = Mathf.Max(0, size.x - reducewidth);
        //    rectTransform.sizeDelta = size;
        //}

    }

    public void StoneDisapp()
    {
        float stoneposy = this.transform.position.y;
        if (stoneposy >= 2.8f)
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        StoneDisapp();
    }
}
