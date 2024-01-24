using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    public int maxBounces;
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;
    // Start is called before the first frame update
    void Start(){
        lr = this.GetComponent<LineRenderer>();
        lr.SetPosition(0, startPoint.position);
    }

    // Update is called once per frame
    void Update(){
        this.CastLaser(transform.position, new Vector3(0,0,1));
    }

    void CastLaser(Vector3 position, Vector3 direction){
        Debug.Log(direction);
        // lr.positionCount = 
        lr.SetPosition(0, startPoint.position);
        
        for(int i=0;i<maxBounces; i++){
            Ray ray = new Ray(position, direction);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5000, 1)){
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i+1, hit.point);
                if(hit.transform.tag != "Mirror"){
                    for(int j=(i+1); j<5; j++){
                        lr.SetPosition(j, hit.point);
                    }
                    break;
                }
            }
        }
    }
}
