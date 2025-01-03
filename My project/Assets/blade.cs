using UnityEngine;

public class blade : MonoBehaviour
{
    public GameObject btrail;
    GameObject currentTrail;
    Vector2 prevPosition;
    public float minVelocity= 0.001f;
   bool isCutting= false;
   Rigidbody2D rb;
   CircleCollider2D cirCollid;
   Camera cam;
    // Update is called once per frame
    void Start(){
        rb=GetComponent<Rigidbody2D>();
        cam=Camera.main;
        cirCollid=GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Vector2 newPosition =cam.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position=newPosition;
startCutting();
        }else if(Input.GetMouseButtonUp(0))
        {
            stopCutting();
        }
        if(isCutting){
            updateCut();
        }
        
    }
 
 void updateCut(){
    Vector2 currPosition=cam.ScreenToWorldPoint(Input.mousePosition);
    rb.position=currPosition;
    float velocity=(currPosition-prevPosition).magnitude/Time.deltaTime;
    if(velocity>minVelocity){
        cirCollid.enabled=false;
    }else{
        cirCollid.enabled=true;
    }
    prevPosition=currPosition;
 }
    void startCutting(){
isCutting=true;


currentTrail=Instantiate(btrail, transform);
prevPosition=cam.ScreenToWorldPoint(Input.mousePosition);
cirCollid.enabled=false;

    }
    void stopCutting(){
isCutting=false;
currentTrail.transform.SetParent(null);
Destroy(currentTrail, 2f);
cirCollid.enabled=false;
    }
}
