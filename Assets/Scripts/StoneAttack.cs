using UnityEngine;

public class StoneAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public SpriteRenderer spriteRenderer;
    public Sprite ChangeStone;
    public Transform Stonehole;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "potion")
        {
            spriteRenderer.sprite = ChangeStone;
            
        }
        if (collision.gameObject.tag == "Catapult")
        {
            this.transform.position = Stonehole.position;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
