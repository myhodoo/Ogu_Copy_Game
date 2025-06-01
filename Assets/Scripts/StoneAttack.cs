using UnityEngine;

public class StoneAttack : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        this.rb = GetComponent<Rigidbody2D>();

        

    }
    public SpriteRenderer spriteRenderer;
    public Sprite ChangeStone;
    public Transform Stonehole;
    public float speed = 3f;
    

    //������ ȿ���� ��Ÿ�� �� scale�� Ŀ���� �۰� �����


    public bool m_ISAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log($"Ȯ�� : {collision.name}, {collision.tag}");
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

                
            }

            m_ISAttack = false;

            
        }

        

        if (collision.gameObject.tag == "Catapult")
        {
            this.transform.position = Stonehole.position;
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
