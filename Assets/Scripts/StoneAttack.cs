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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "potion")
        {
            spriteRenderer.sprite = ChangeStone;
            //this.gameObject.layer = 7;
            
        }
        if (collision.gameObject.tag == "Catapult")
        {
            this.transform.position = Stonehole.position;
        }


        if(this.transform.position == Stonehole.position)
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            
            if(collision.gameObject.tag == "knife")
            {
                //this.rb.isKinematic = false;

                this.transform.position = Vector3.MoveTowards(this.transform.position, ArrivePos, speed * Time.deltaTime);
                if (  this.transform.position == ArrivePos)
                {
                    Destroy(this.gameObject);
                }
            }

        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
