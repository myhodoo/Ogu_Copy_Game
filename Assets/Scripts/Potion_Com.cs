using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Com : MonoBehaviour
{

    public Sprite ChangeSprite;
    public float ChangeWellDelaySec = 5;

    public void SetWaterWell()
    {
        this.GetComponent<SpriteRenderer>().sprite = ChangeSprite;
        //spriteRenderer.sprite = ChangeSprite;
        this.transform.localScale = new Vector3(5f, 5f, 4.32229996f);


        int layerindex = LayerMask.NameToLayer("Water");
        this.gameObject.layer = layerindex;


        float zwater = this.transform.position.z;
        zwater = 0.6f;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, zwater);

        GetComponent<Collider2D>().isTrigger = true;


        StartCoroutine( DelayDestroy() ); 

    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(ChangeWellDelaySec);

        GameObject.Destroy(this.gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
