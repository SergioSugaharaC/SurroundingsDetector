using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour{
    [SerializeField] private float vRadius;

    private List<GameObject> targetsAround;
    private LayerMask targetMask;
    private LayerMask obstacleMask;
    private SphereCollider sc;
    Collider[] targets;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine("FindTargetsDelay", 0.3f);
        //obstacleMask = LayerMask.GetMask(LayerMask.LayerToName(6));
        targetMask = LayerMask.GetMask(LayerMask.LayerToName(6));
        targetsAround = new List<GameObject>();
        sc = gameObject.GetComponent<SphereCollider>();
    }

    IEnumerator FindTargetsDelay(float delay){
        while(true){
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            GetPoints();
        }
    }

    private void FindVisibleTargets(){
        //ClearList();
        targetsAround.Clear();
        Collider[] targetsFound = Physics.OverlapSphere(
            transform.position, vRadius, targetMask);
        for(int i = 0; i < targetsFound.Length; i++){
            GameObject target = targetsFound[i].gameObject;
            targetsAround.Add(target);
        }
    }

    private void GetPoints(){
        if(targetsAround.Count > 0){
            GameObject points;
            Transform[] allChildren;
            foreach(GameObject go in targetsAround){
                print(go.tag);
                points = go.transform.GetChild(0).gameObject;
                allChildren = points.GetComponentsInChildren<Transform>();
                
                foreach(Transform t in allChildren){
                    print(t.gameObject.name + ": " + t.position);
                }
            }
        }
    }

    /*
    private void ClearList(){
        if(visibleTargets.Count > 0){
            foreach(GameObject go in visibleTargets){
                if(numPlayer == 1) go.GetComponent<Interactions>().ColorP1 = new Vector4(0f,0f,0f,0f);
                if(numPlayer == 2) go.GetComponent<Interactions>().ColorP2 = new Vector4(0f,0f,0f,0f);
                //visibleTargets.Remove(go);
            }
            visibleTargets.Clear();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        print(targetsAround.Count);
    }
    /*
    private void OnTriggerEnter(Collider other) {
        targetsAround.Add(other.gameObject);
    }*/
}
