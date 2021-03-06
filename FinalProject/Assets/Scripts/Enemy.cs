﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    public float speed;
    public int health;
    public Sprite[] sprites;

    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject itemCoin;
    public GameObject itemPower;
    public GameObject itemBoom;
    public GameObject player;
    public ObjectManager objectManager;
    public GameManager gameManager;

 

    SpriteRenderer spriteRenderer;
    Animator anim;

    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;
        
    void Awake()
    {
        spriteRenderer =  GetComponent<SpriteRenderer>();
        
        if((enemyName =="B")||(enemyName =="B2")||(enemyName =="B3"))
            anim = GetComponent<Animator>();
        
    }

    void OnEnable()
    {
        switch (enemyName){
            case "B":
                health =700;
                Invoke("Stop",2);
                break;
            case "L":
                health =50;
                break;
            case "L2":
                health =50;
                break;
            case "M":
                health = 15;
                break;
            case "S":
                health=3;
                break;
            case "S2":
                health=3;
                break;
            case "S3":
                health=3;
                break;
            case "M2":
                health=15;
                break;
            case "R":
                health=1;
                break;
            case "R2":
                health=5;
                break;
            case "B2":
                health =700;
                Invoke("Stop",2);
                break;
            case "B3":
                health =700;
                Invoke("Stop",2);
                break;
            
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf)
            return;
        
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Think", 2);
    }

    void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch (patternIndex){
            case 0:
                FireFoward();
                break;
            case 1:
                FireShot();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
        }
    }

    void FireFoward()
    {
        if (health <= 0) 
            return;
        //Fire 4 bullets forward
        GameObject bulletR = objectManager.MakeObj("BulletBossA");
        bulletR.transform.position = transform.position + Vector3.right*0.3f;
        GameObject bulletRR = objectManager.MakeObj("BulletBossA");
        bulletRR.transform.position = transform.position + Vector3.right*0.45f;
        GameObject bulletL = objectManager.MakeObj("BulletBossA");
        bulletL.transform.position = transform.position + Vector3.left*0.3f;    
        GameObject bulletLL = objectManager.MakeObj("BulletBossA");
        bulletLL.transform.position = transform.position + Vector3.left*0.45f;
            
        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
        
        
        rigidR.AddForce(Vector2.down*8, ForceMode2D.Impulse);
        rigidRR.AddForce(Vector2.down*8, ForceMode2D.Impulse);
        rigidL.AddForce(Vector2.down*8, ForceMode2D.Impulse);
        rigidLL.AddForce(Vector2.down*8, ForceMode2D.Impulse);

        //Pattern Counting
        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireFoward", 2);
        else   
            Invoke("Think", 3);
    }

    void FireShot()
    {
        if (health <= 0) 
            return;
        for(int index=0; index<5; index++){
            GameObject bullet = objectManager.MakeObj("BulletEnemyB");
            bullet.transform.position = transform.position; 
            
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
            dirVec += ranVec;
            rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
       }

        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireShot", 3.5f);
        else   
            Invoke("Think", 3);
    }

    void FireArc()
    {
        if (health <= 0) 
            return;
        //Fire Arc Continue Fire
        GameObject bullet = objectManager.MakeObj("BulletEnemyA");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity; 
            
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 10 * curPatternCount/maxPatternCount[patternIndex]), -1);
        rigid.AddForce(dirVec.normalized*5, ForceMode2D.Impulse);

       //Pattern Counting
       curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireArc", 0.15f);
        else   
            Invoke("Think", 3);
    }

    void FireAround()
    {
        if (health <= 0) 
            return;
        //Fire Around
        int roundNumA =50;
        int roundNumB =40;
        int roundNum = curPatternCount % 2 == 0 ? roundNumA : roundNumB;

        for(int index=0; index < roundNum; index++){
            GameObject bullet = objectManager.MakeObj("BulletBossB");
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity; 
            
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index/roundNum)
                                        ,Mathf.Sin(Mathf.PI * 2 * index/roundNum));

            rigid.AddForce(dirVec.normalized*2, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * index / roundNum + Vector3.forward*90;
            bullet.transform.Rotate(rotVec);
        }


        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
            Invoke("FireAround", 0.7f);
        else   
            Invoke("Think", 3);
    }

     void Update()
    {
        if ((enemyName =="B")||(enemyName =="B2")||(enemyName =="B3"))
            return;


        Fire();
        Reload();
    }

    void Fire()
    {
        
        if(curShotDelay < maxShotDelay)
            return;

        if(enemyName == "S"){
            GameObject bullet = objectManager.MakeObj("BulletEnemyA");
            bullet.transform.position = transform.position; 
            
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
        }

         if(enemyName == "S2"){
            GameObject bullet = objectManager.MakeObj("BulletEnemyA");
            bullet.transform.position = transform.position; 
            
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
        }

        if(enemyName == "S3"){
            GameObject bullet = objectManager.MakeObj("BulletLaser");
            bullet.transform.position = transform.position; 
            
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized*3, ForceMode2D.Impulse);
        }

        if (enemyName == "M2"){
            GameObject bulletR = objectManager.MakeObj("BulletEnemyA");
            bulletR.transform.position = transform.position + Vector3.right*0.3f;
            
            GameObject bulletL = objectManager.MakeObj("BulletEnemyA");
            bulletL.transform.position = transform.position + Vector3.left*0.3f;
            
            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right*0.3f);
            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left*0.3f);
        
            rigidR.AddForce(dirVecR.normalized*4, ForceMode2D.Impulse);
            rigidL.AddForce(dirVecL.normalized*4, ForceMode2D.Impulse);
        }

        if (enemyName == "L2"){
            GameObject bulletR = objectManager.MakeObj("BulletLaser2");
            bulletR.transform.position = transform.position + Vector3.right*0.3f;
            
            GameObject bulletL = objectManager.MakeObj("BulletLaser2");
            bulletL.transform.position = transform.position + Vector3.left*0.3f;
            
            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right*0.3f);
            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left*0.3f);
        
            rigidR.AddForce(dirVecR.normalized*4, ForceMode2D.Impulse);
            rigidL.AddForce(dirVecL.normalized*4, ForceMode2D.Impulse);
        }

        else if (enemyName == "L"){
            GameObject bulletR = objectManager.MakeObj("BulletEnemyB");
            bulletR.transform.position = transform.position + Vector3.right*0.3f;
            
            GameObject bulletL = objectManager.MakeObj("BulletEnemyB");
            bulletL.transform.position = transform.position + Vector3.left*0.3f;
            
            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();

            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right*0.3f);
            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left*0.3f);
        
            rigidR.AddForce(dirVecR.normalized*4, ForceMode2D.Impulse);
            rigidL.AddForce(dirVecL.normalized*4, ForceMode2D.Impulse);
        }

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    public void OnHit(int dmg)
    {
        if (health <= 0)
            return;
            
        health -= dmg;

        if ((enemyName =="B")||(enemyName =="B2")||(enemyName =="B3"))
        {
            anim.SetTrigger("OnHit");
        }
        

        else
        {
            spriteRenderer.sprite =  sprites[1]; 
            Invoke("ReturnSprite", 0.1f);
        }

        if(health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;

            //Random Ratio Item Drop
            int ran = ((enemyName == "B")||(enemyName =="B2")||(enemyName =="B3")) ? 0 : Random.Range(0,10);    //Boss will not drop any item
            

            if(ran < 3){
                Debug.Log("Not Item");
            }
            else if (ran < 6){   //Coin 30%
                GameObject itemCoin = objectManager.MakeObj("ItemCoin");
                itemCoin.transform.position = transform.position;
            }
            else if (ran < 8){   //Power 20%
                GameObject itemPower = objectManager.MakeObj("ItemPower");
                itemPower.transform.position = transform.position;
            }
            else if (ran < 10){  //Boom 20%
                GameObject itemBoom = objectManager.MakeObj("ItemBoom");
                itemBoom.transform.position = transform.position;
            }

            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
            gameManager.CallExplosion(transform.position, enemyName);
            
            //Boss Kill
            if((enemyName =="B")||(enemyName =="B2"))
                gameManager.StageEnd();
           
            
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite =  sprites[0]; 

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderBullet" && enemyName != "B")
        {
            gameObject.SetActive(false);
            transform.rotation = Quaternion.identity;
        }

        
            
        else if(collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet =  collision.gameObject.GetComponent<Bullet>(); 
            OnHit(bullet.dmg);

            collision.gameObject.SetActive(false);

        }   
    }
   
}
