using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{

    public Image EnemyFill = null;

    public float Maxhp = 95f;
    public float CurrentHp;
  


    protected float OneUISize = 0f;


    public Slider LinkHpBarSlider = null;

    void Start()
    {
        CurrentHp = Maxhp;

        LinkHpBarSlider.minValue = 0;
        LinkHpBarSlider.maxValue = CurrentHp;
        LinkHpBarSlider.value = CurrentHp;
    }

    public void TakeDamage(float damage)
    {

        // 100 - 1.5f
        CurrentHp -= damage;

        Debug.Log($"데미지 : {CurrentHp}, {damage}");

        CurrentHp = Mathf.Clamp(CurrentHp, 0, Maxhp);
        if (CurrentHp <= 0)
        {
            Debug.Log("보스사망");
        }

        LinkHpBarSlider.value = CurrentHp;

        

        //RectTransform rectTransform = EnemyFill.GetComponent<RectTransform>();
        //Vector3 fillsize = rectTransform.sizeDelta;
        //fillsize.x = CurrentHp - damage;
        //rectTransform.sizeDelta = fillsize;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "StoneChange")
        {
            TakeDamage(20f);
        }
        Debug.Log($"보스 충돌 : {collision.name}, {collision.tag} ");
        if(collision.gameObject.tag == "stone")
        {
            TakeDamage(10f);
        }
    }





    void Update()
    {
        
    }
}
