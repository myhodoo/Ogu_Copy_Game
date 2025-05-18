using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public SpriteRenderer spriteRenderer;
    public Sprite ChangeSprite;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{this.gameObject.tag}, {collision.gameObject.tag}");
        if (collision.gameObject.tag == "potion")
        {
            spriteRenderer.sprite = ChangeSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Æ®¸®°Å {this.gameObject.tag}, {collision.gameObject.tag}");
        if (collision.gameObject.tag == "potion")
        {
            collision.GetComponent<SpriteRenderer>().sprite = ChangeSprite;
            //spriteRenderer.sprite = ChangeSprite;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
