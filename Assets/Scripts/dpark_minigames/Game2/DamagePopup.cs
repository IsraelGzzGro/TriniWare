using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    public static DamagePopup Create(Vector3 position, int damageAmount){
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveYSpd = 1f;
        transform.position += new Vector3(0, MoveYSpd) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0){
            float dissappearSpd = 3f;
            textColor.a -= dissappearSpd * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Mouse0)) textMesh.color = textColor;
            if(textColor.a < 0) Destroy(gameObject);
        }
    }

    void Awake(){
        //masherScript = Transform.Find("pfDamagePopup").GetComponent<MasherScript>();
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount){
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

}
