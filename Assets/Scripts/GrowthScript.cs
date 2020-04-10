using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float stemSize = 0.0f;
    private float branch1Size = 0.0f;

    private float branch2Size = 0.0f;

    private float branch1_leaf1Size = 0.0f;

    private float branch1_leaf2Size = 0.0f;

    private float branch2_leaf1Size = 0.0f;

    private float branch2_leaf2Size = 0.0f;

    public GameObject branch1;

    public GameObject branch2;

    public GameObject branch1_leaf1;

    public GameObject branch1_leaf2;

    public GameObject branch2_leaf2;

    public GameObject branch2_leaf1;
    void Start()
    {
        InvokeRepeating("stemGrow", 0.0f, 0.01f);
        branch1.GetComponent<Renderer>().enabled = false;
        branch2.GetComponent<Renderer>().enabled = false;
        branch1_leaf1.GetComponent<Renderer>().enabled = false;
        branch1_leaf2.GetComponent<Renderer>().enabled = false;
        branch2_leaf1.GetComponent<Renderer>().enabled = false;
        branch2_leaf2.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void stemGrow() {
        if(stemSize>=100.0f) {
            CancelInvoke("stemGrow");
        }
        if(stemSize == 50.0f){
            branch1.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch1Grow", 0.0f, 0.01f);
        }
        if(stemSize == 70.0f){
            branch2.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch2Grow", 0.0f, 0.01f);
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, stemSize++);
    }

    void branch1Grow() {
        if(branch1Size>=100.0f) {
            CancelInvoke("branch1Grow");
        }
        branch1.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch1Size++);
        if(branch1Size == 50.0f){
            branch1_leaf1.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch1_leaf1Grow", 0.0f, 0.01f);
        }
        if(branch1Size == 70.0f){
            branch1_leaf2.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch1_leaf2Grow", 0.0f, 0.01f);
        }
    }

    void branch2Grow() {
        if(branch2Size>=100.0f) {
            CancelInvoke("branch2Grow");
        }
        branch2.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch2Size++);
        if(branch2Size == 50.0f){
            branch2_leaf1.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch2_leaf1Grow", 0.0f, 0.01f);
        }
        if(branch2Size == 70.0f){
            branch2_leaf2.GetComponent<Renderer>().enabled = true;
            InvokeRepeating("branch2_leaf2Grow", 0.0f, 0.01f);
        }
    }

    void branch1_leaf1Grow(){
        if(branch1_leaf1Size>=25.0f) {
            CancelInvoke("branch1_leaf1Grow");
        }
        branch1_leaf1.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch1_leaf1Size++);
    }

    void branch1_leaf2Grow(){
        if(branch1_leaf2Size>=25.0f) {
            CancelInvoke("branch1_leaf2Grow");
        }
        branch1_leaf2.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch1_leaf2Size++);
    }

    void branch2_leaf1Grow(){
        if(branch2_leaf1Size>=25.0f) {
            CancelInvoke("branch2_leaf1Grow");
        }
        branch2_leaf1.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch2_leaf1Size++);
    }

    void branch2_leaf2Grow(){
        if(branch2_leaf2Size>=25.0f) {
            CancelInvoke("branch2_leaf2Grow");
        }
        branch2_leaf2.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, branch2_leaf2Size++);
    }
}
