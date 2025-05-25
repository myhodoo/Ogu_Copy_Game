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
    public Vector3 ArrivePos;
    public float speed = 3f;

    //던지는 효과를 나타낼 때 scale을 커지고 작게 만들기


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
                if (this.transform.position == ArrivePos)
                {
                    Destroy(this.gameObject);
                }
            }

            m_ISAttack = false;
        }

        if (collision.gameObject.tag == "Catapult")
        {
            this.transform.position = Stonehole.position;
            m_ISAttack = true;
        }

        
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
