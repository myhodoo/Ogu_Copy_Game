using System.Collections;
using UnityEngine;

public class StoneAttack : MonoBehaviour
{
    //코르틴 사용해서 돌 포물선 그리면서 이동하는 것 처럼 만들기



    Rigidbody2D rb;
    void Start()
    {
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

    private float size = 5.59f;
    public float upspeed;
    private Vector2 originscale;
    private float time;

    IEnumerator Up_Coroutine()
    {
        if (transform.position.y >= -0.32f)
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

            //if(this.transform.position.y > 2.8f)
            //{
            //    yield break;
            //}

        }


        while (transform.localScale.x < size)
        {
            this.transform.localScale = originscale * (1f + time * upspeed) ;
            time += Time.deltaTime;

            if(transform.localScale.x >= size)
            {
                time = 0;
                break; 
            }

            yield return null;
        }

        

    }


    public bool m_ISAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log($"확인 : {collision.name}, {collision.tag}");
        if (collision.gameObject.tag == "potion")
        {
            spriteRenderer.sprite = ChangeStone;
            //this.gameObject.layer = 7;
            
        }

        if (m_ISAttack)
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            if (collision.gameObject.tag == "knife")
            {
                //this.rb.isKinematic = false;

                this.GetComponent<Collider2D>().isTrigger = true;
                this.rb.velocity = Vector3.up * speed;


                StartCoroutine(Up_Coroutine());
            }

            m_ISAttack = false;

            
        }

        

        if (collision.gameObject.tag == "Catapult")
        {
            this.transform.position = new Vector3(Stonehole.position.x, Stonehole.position.y, 0);
            m_ISAttack = true;
        }
        
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
