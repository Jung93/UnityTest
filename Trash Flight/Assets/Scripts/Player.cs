using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    [SerializeField] 
    private float moveSpeed; 
    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private float shootInterval = 0.1f;
    private float lastShootTime = 0f;


    // private float 

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        
        // Vector3 moveTo = new Vector3(horizontalInput,verticalInput,0f);

        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        float toY = Mathf.Clamp(mousePos.y, -4.3f, 4.3f);

        transform.position = new Vector3(toX, toY,transform.position.z);

        if(!GameManager.instance.isGameOver){
            Shoot();
        }

    }

    void Shoot(){

        if(Time.time - lastShootTime > shootInterval){
       
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);

            lastShootTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
            GameManager.instance.SetGameOver();
            Destroy(gameObject);

        } else if(other.gameObject.tag == "Coin"){
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }

    }

    public void UpgradeWeapon(){
        weaponIndex++;
        if(weaponIndex >= weapons.Length){
            weaponIndex = weapons.Length - 1;
        }

    }


}
