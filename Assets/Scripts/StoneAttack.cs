using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoneAttack : MonoBehaviour
{
    //�ڸ�ƾ ����ؼ� �� ������ �׸��鼭 �̵��ϴ� �� ó�� �����



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


    //������ ȿ���� ��Ÿ�� �� scale�� Ŀ���� �۰� �����
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
            // ���� �����Ͽ� �����Ϻ��� �� ����
            Vector3 changesize = (divsize * Time.deltaTime) + this.transform.localScale;

            // Ư�� ������ �̻��̵Ǹ� ����
            if (changesize.x >= size)
            {
                changesize.x = size;
                changesize.y = size;
                changesize.z = size;
            }
            this.transform.localScale = changesize;

            // y���� 0�̻��̵Ǹ� while ����
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


            // ���� ������� ������ ���������� �۾����� �ϱ�
            Vector3 changesize = this.transform.localScale - (divsize * Time.deltaTime);
            // �ʹ� �۾����°� Ư��ũ��� ����
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
        Debug.Log($"Ȯ�� : {collision.name}, {collision.tag}");
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
            // ����� stone�� Stonehole ��ġ���� ���߱� -> ����� stone�� stonehole ���� ����
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
