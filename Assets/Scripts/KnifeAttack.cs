using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"{this.gameObject.tag}, {collision.gameObject.tag}");
    //    if (collision.gameObject.tag == "potion")
    //    {
    //        spriteRenderer.sprite = ChangeSprite;
    //    }
    //}


    public SpriteRenderer spriteRenderer;
    public Sprite ChangeSprite;

    public bool isTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"트리거 {this.gameObject.tag}, {collision.gameObject.tag}");
        // 기존 방법
        if ( false )
        {
            Debug.Log($"트리거 {this.gameObject.tag}, {collision.gameObject.tag}");
            if (collision.gameObject.tag == "potion")
            {
                collision.GetComponent<SpriteRenderer>().sprite = ChangeSprite;
                //spriteRenderer.sprite = ChangeSprite;
                collision.transform.localScale = new Vector3(5f, 5f, 4.32229996f);


                int layerindex = LayerMask.NameToLayer("Water");
                collision.gameObject.layer = layerindex;


                float zwater = collision.transform.position.z;
                zwater = 0.6f;
                collision.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, zwater);

                collision.isTrigger = true;


                //GameObject.Destroy(collision.gameObject, 3f);
            }
        }
        else
        {
            Potion_Com com = collision.GetComponent<Potion_Com>();
            if (com != null)
            {
                com.SetWaterWell();
            }
        }
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
