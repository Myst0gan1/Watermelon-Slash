using UnityEngine;

public class fruit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject fruitPrefab;
    Rigidbody2D rb;
    public float startForce=13f;

void Start(){
    rb=GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up*startForce, ForceMode2D.Impulse);
}
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="blade"){

            Vector3 direction=(col.transform.position-transform.position).normalized;
            Quaternion rotation=Quaternion.LookRotation(direction);

           GameObject slicedFruit= Instantiate(fruitPrefab, transform.position, rotation);
           Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
