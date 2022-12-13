using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasherScript : MonoBehaviour
{
    public GameObject Heals;
    public GameObject[] Enemies;
    private GameObject enem;
    private Vector3 center = new Vector3(0, -1, 0);

    private float healthRate;
    private int add_health;
    public int health;
    private int min_dam;
    private int max_dam;
    private int chance_heal; // 1/n chance to gain health
    public bool alive = true;
    private int max_health;
    private string Name;

    //HealthBar
    public Text healthText;
    public Image healthBar;
    private float health_percentage;
    float LerpSpd;

    //Damage_Numbers
    public Transform pfDamagePopup;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public GameObject explosion;
    public int cnt = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        int randEnemy = Random.Range(0, 9);
        Debug.Log(randEnemy);
        if(randEnemy <= 4){ //50% Easy Enemy
            GameObject boss1 = Instantiate(Enemies[0], center, Quaternion.identity);
            add_health = 3;
            max_health = 200;
            health = max_health;
            min_dam = 2;
            max_dam = 5;
            chance_heal = 4;
            Name = "Slime";
        }
        if(randEnemy > 4 && randEnemy <= 7){ //30% Medium Enemy
            GameObject boss2 = Instantiate(Enemies[1], center, Quaternion.identity);
            add_health = 6;
            max_health = 300;
            health = max_health;
            min_dam = 3;
            max_dam = 7;
            chance_heal = 3;
            Name = "Orange Mushroom";
        }
        if(randEnemy > 7 && randEnemy <= 9){ //20% Hard Enemy
            GameObject boss3 = Instantiate(Enemies[2], center, Quaternion.identity);
            add_health = 20;
            max_health = 500;
            health = max_health;
            min_dam = 5;
            max_dam = 11;
            chance_heal = 2;
            Name = "Blue Mushroom";
        }
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = 1;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        LerpSpd = 3f * Time.deltaTime;
        healthText.text = Name + ": HP " + health;
        HealthBarFiller();
        ColorChanger();

        //If enemy dies
        if(health > 0 && alive){

            //Enemy Damage Mechanic
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                DamagePopup.Create(screenPosition, 12);
                int dam_range = Random.Range(min_dam, max_dam + 1);
                if(health - dam_range < 0) health = 0; //If health goes negative, set to 0
                else health -= dam_range;
                DamagePopup.Create(worldPosition, dam_range);
            }

            //Enemy Healing Mechanic
            healthRate -= Time.deltaTime;
            if(healthRate <= 0){
                healthRate = 1f;

                //Roll random number, health_rand
                int health_rand = Random.Range(0, chance_heal); //Coin Flip

                if(health_rand == 0 && health < max_health){
                    if(health + add_health > max_health) health = max_health;
                    else health += add_health;
                    float x_pos = Random.Range(-3.0f, 3.0f);
                    float y_pos = Random.Range(-1.0f, 2.5f);
                    //Health Animation
                    GameObject e = Instantiate(Heals) as GameObject;
                    e.transform.position = center + new Vector3(x_pos, y_pos, 0);
                    Object.Destroy(e, 2.0f);
                }
            }
        } else { //Boss has died (Condition for minigame to end)
            if(cnt == 1){
                alive = false;
                GameObject e = Instantiate(explosion) as GameObject;
                e.transform.position = center;
                Object.Destroy(e, 2.0f);
                Debug.Log("Moster has Died!");
                cnt -= 1;
            }
        }
    }

    void PlayDead() {
        //What to play when enemy is dead
    }

    void HealthBarFiller(){
        float h = health;
        float m = max_health;
        health_percentage = h/m; //Should return a number between 0 and 1
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health_percentage, LerpSpd);
    }

    void ColorChanger(){
        float h = health;
        float m = max_health;
        health_percentage = h/m;
        Color healthColor = Color.Lerp(Color.red, Color.green, health_percentage);
        healthBar.color = healthColor;
    }
}
