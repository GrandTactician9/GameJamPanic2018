using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject player;
    public Rigidbody rb;
    public float x;
    public float y;
    public float topSpeed;
    public int itemCount = 0;
    float time;
    public int health = 5;
    public List <Sprite> healthPictures;
    public Image healthPicture;

    public int Health {
        get { return health; }
        set {
            healthPicture.sprite = healthPictures[health];
            health = value;
        }
    }

    // public GunType gun;
    //public int weaponType = 0;

    public void getHurt()
    {
            Health--;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "end")
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);          
            Destroy(player);
            
        }

    }

    void movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(x, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-x, 0, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0, y, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(0, -y, 0));
        }

        
    }
        // Use this for initialization
        void Start () {
        rb = GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
	void Update () {
        movement();

        if (itemCount == 1)
        {
            time += Time.deltaTime;
            x = 250;
            y = 250;
            if (time == 2.0)
            {
                itemCount = 0;
                x = 100;
                y = 100;
            }
        }


        // 5 second speed powerup and 5 health



        /* if (itemCount == 1)                   // weapon types
         {
             gun = GunType.Shotgun;

         }

     /* if (Input.GetKey(KeyCode.Space))
      {
          if (gun == GunType.Pistol && itemCount == 1)
          {
              gun = GunType.Pistol;
              weaponType = 0;
          }
          else if (weaponType == 0 && itemCount == 1)
          {
              gun = GunType.Shotgun;
              weaponType = 1;
          }
      }*/


    } // update bracket

    /* public enum GunType
     {
         Pistol,
         Shotgun,
     }
     */
}
