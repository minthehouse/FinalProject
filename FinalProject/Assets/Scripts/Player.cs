using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public int life;
    public int score;
    public float speed;
    public int power;
    public int maxPower;
    public int maxBoom;
    public int boom;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject boomEffect;

    public GameManager gameManager;
    public ObjectManager objectManager;
    public bool isHit;
    public bool isBoomTime;

    public GameObject[] followers;
    public bool isRespawnTime;

    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        Unbeatable();
        Invoke("Unbeatable", 3);
    }

    void Unbeatable()
    {
        isRespawnTime= !isRespawnTime;

        if (isRespawnTime){
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);

            for(int index=0; index<followers.Length; index++){
                followers[index].GetComponent<SpriteRenderer>().color =new Color(1, 1, 1, 0.5f);
            }
        }
        else {
            spriteRenderer.color = new Color(1, 1, 1, 1);

            for(int index=0; index<followers.Length; index++){
                followers[index].GetComponent<SpriteRenderer>().color =new Color(1, 1, 1, 1);
            }
        }
    }

    void Update()
    {
        Move();
        Fire();
        Boom();
        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if( (isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h=0;

        float v = Input.GetAxisRaw("Vertical");
        if( (isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v=0;
        
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h,v,0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if(Input.GetButtonDown("Horizontal")|| Input.GetButtonUp("Horizontal")){
            anim.SetInteger("Input", (int)h);
        }
    }

    void Fire()
    {
        if(!Input.GetButton("Fire1"))
        {
            return;
        }
            
        
        if(curShotDelay < maxShotDelay)
            return;



        if ((SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[1]Stage1")) ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[1]Stage3"))
            ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[1]Stage2")) )        
        {
            switch(power) 
            {
                    case 1:

                        //Power One
                        SoundManager.PlaySound("shooting");
                        GameObject bullet = objectManager.MakeObj("BulletPlayerA");
                        bullet.transform.position = transform.position; 
                
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break; 

                
                
                    case 2:
                        SoundManager.PlaySound("shooting");
                        GameObject bulletR = objectManager.MakeObj("BulletPlayerA");
                        bulletR.transform.position = transform.position + Vector3.right * 0.1f; 
                
                        GameObject bulletL = objectManager.MakeObj("BulletPlayerA");
                        bulletL.transform.position = transform.position + Vector3.left * 0.1f; 
                
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;

                    default:
                        SoundManager.PlaySound("shooting");
                
                        GameObject bulletRR = objectManager.MakeObj("BulletPlayerA");
                        bulletRR.transform.position = transform.position + Vector3.right * 0.35f; 
              
                        GameObject bulletCC = objectManager.MakeObj("BulletPlayerB");
                        bulletCC.transform.position = transform.position;

                        GameObject bulletLL = objectManager.MakeObj("BulletPlayerA");
                        bulletLL.transform.position = transform.position + Vector3.left * 0.35f; 
                
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;
            }
        }

        if ((SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[2]Stage1")) ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[2]Stage3"))
            ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[2]Stage2")) )        
        {
            switch(power) 
            {
                    case 1:

                        //Power One
                        SoundManager.PlaySound("shooting");
                        GameObject bullet = objectManager.MakeObj("BulletPlayerH");
                        bullet.transform.position = transform.position; 
                
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break; 

                
                
                    case 2:
                        SoundManager.PlaySound("shooting");
                        GameObject bulletR = objectManager.MakeObj("BulletPlayerH");
                        bulletR.transform.position = transform.position + Vector3.right * 0.1f; 
                
                        GameObject bulletL = objectManager.MakeObj("BulletPlayerH");
                        bulletL.transform.position = transform.position + Vector3.left * 0.1f; 
                
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;

                    default:
                        SoundManager.PlaySound("shooting");
                
                        GameObject bulletRR = objectManager.MakeObj("BulletPlayerH");
                        bulletRR.transform.position = transform.position + Vector3.right * 0.35f; 
              
                        GameObject bulletCC = objectManager.MakeObj("BulletPlayerH2");
                        bulletCC.transform.position = transform.position;

                        GameObject bulletLL = objectManager.MakeObj("BulletPlayerH");
                        bulletLL.transform.position = transform.position + Vector3.left * 0.35f; 
                
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;
            }
        }

        if ((SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[3]Stage1")) ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[3]Stage3"))
            ||(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("[3]Stage2")) )        
        {
            switch(power) 
            {
                    case 1:

                        //Power One
                        SoundManager.PlaySound("shooting");
                        GameObject bullet = objectManager.MakeObj("BulletPlayerW");
                        bullet.transform.position = transform.position; 
                
                        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                        rigid.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break; 

                
                
                    case 2:
                        SoundManager.PlaySound("shooting");
                        GameObject bulletR = objectManager.MakeObj("BulletPlayerW");
                        bulletR.transform.position = transform.position + Vector3.right * 0.1f; 
                
                        GameObject bulletL = objectManager.MakeObj("BulletPlayerW");
                        bulletL.transform.position = transform.position + Vector3.left * 0.1f; 
                
                        Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                        rigidR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;

                    default:
                        SoundManager.PlaySound("shooting");
                
                        GameObject bulletRR = objectManager.MakeObj("BulletPlayerW");
                        bulletRR.transform.position = transform.position + Vector3.right * 0.35f; 
              
                        GameObject bulletCC = objectManager.MakeObj("BulletPlayerW2");
                        bulletCC.transform.position = transform.position;

                        GameObject bulletLL = objectManager.MakeObj("BulletPlayerW");
                        bulletLL.transform.position = transform.position + Vector3.left * 0.35f; 
                
                        Rigidbody2D rigidRR = bulletRR.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidCC = bulletCC.GetComponent<Rigidbody2D>();
                        Rigidbody2D rigidLL = bulletLL.GetComponent<Rigidbody2D>();
                        rigidRR.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidCC.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        rigidLL.AddForce(Vector2.up*10, ForceMode2D.Impulse);
                        break;
            }
        }
        
        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void Boom()
    {
        if (!Input.GetButton("Fire2"))
            return;
        
        if (isBoomTime)
            return;

        if (boom == 0)
            return;
        
        SoundManager.PlaySound("boom");

        boom--;
        isBoomTime = true;
        gameManager.UpdateBoomIcon(boom);

        //Effect visible
        boomEffect.SetActive(true);
        Invoke("OffBoomEffect",4f);

        //Remove Enemy
        GameObject[] enemiesL = objectManager.GetPool("EnemyL");
        GameObject[] enemiesL2 = objectManager.GetPool("EnemyL2");
        GameObject[] enemiesM = objectManager.GetPool("EnemyM");
        GameObject[] enemiesM2 = objectManager.GetPool("EnemyM2");
        GameObject[] enemiesS = objectManager.GetPool("EnemyS");
        GameObject[] enemiesS2 = objectManager.GetPool("EnemyS2");
        GameObject[] enemiesS3 = objectManager.GetPool("EnemyS3");
        GameObject[] enemiesR = objectManager.GetPool("EnemyR");
        GameObject[] enemiesR2 = objectManager.GetPool("EnemyR2");

        for(int index=0; index < enemiesL.Length; index++){
            if (enemiesL[index].activeSelf){
                Enemy enemyLogic = enemiesL[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesL2.Length; index++){
            if (enemiesL2[index].activeSelf){
                Enemy enemyLogic = enemiesL2[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesM.Length; index++){
            if (enemiesM[index].activeSelf){
                Enemy enemyLogic = enemiesM[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesM2.Length; index++){
            if (enemiesM2[index].activeSelf){
                Enemy enemyLogic = enemiesM2[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesS.Length; index++){
            if (enemiesS[index].activeSelf){
                Enemy enemyLogic = enemiesS[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesS2.Length; index++){
            if (enemiesS2[index].activeSelf){
                Enemy enemyLogic = enemiesS2[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesS3.Length; index++){
            if (enemiesS3[index].activeSelf){
                Enemy enemyLogic = enemiesS3[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesR.Length; index++){
            if (enemiesR[index].activeSelf){
                Enemy enemyLogic = enemiesR[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        for(int index=0; index < enemiesR2.Length; index++){
            if (enemiesR2[index].activeSelf){
                Enemy enemyLogic = enemiesR2[index].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }
        }

        

        //Remove Enemy Bullet
        GameObject[] bulletsA = objectManager.GetPool("BulletEnemyA");
        GameObject[] bulletsB = objectManager.GetPool("BulletEnemyB");

        GameObject[] bulletsBA = objectManager.GetPool("BulletBossA");
        GameObject[] bulletsBB = objectManager.GetPool("BulletBossB");
        GameObject[] bulletsL = objectManager.GetPool("BulletLaser");
        GameObject[] bulletsL2 = objectManager.GetPool("BulletLaser2");
        
        for(int index=0; index < bulletsA.Length; index++){
            if (bulletsA[index].activeSelf){
                bulletsA[index].SetActive(false);
            }
        }

        for(int index=0; index < bulletsB.Length; index++){
            if (bulletsB[index].activeSelf){
                bulletsB[index].SetActive(false);
            }
        }

        for(int index=0; index < bulletsBA.Length; index++){
            if (bulletsBA[index].activeSelf){
                bulletsBA[index].SetActive(false);
            }
        }

        for(int index=0; index < bulletsBB.Length; index++){
            if (bulletsBB[index].activeSelf){
                bulletsBB[index].SetActive(false);
            }
        }

        for(int index=0; index < bulletsL.Length; index++){
            if (bulletsL[index].activeSelf){
                bulletsL[index].SetActive(false);
            }
        }

        for(int index=0; index < bulletsL2.Length; index++){
            if (bulletsL2[index].activeSelf){
                bulletsL2[index].SetActive(false);
            }
        }
    

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border"){
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet"){
            
            if(isRespawnTime)
                return;

            if(isHit)
                return;

            isHit = true;
            life--;
            gameManager.UpdateLifeIcon(life);
            gameManager.CallExplosion(transform.position, "P");

            if(life ==0){
                gameManager.GameOver();
            }
            else {
                gameManager.RespawnPlayer();
            }

            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Item"){

            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type){

                case "Coin":
                    SoundManager.PlaySound("coin");
                    score += 1000;
                    break;
                case "Power":
                    SoundManager.PlaySound("item");
                    if(power == maxPower)
                        score += 500;
                    else{
                        power++;
                        AddFollower();
                    }
                    break;
                case "Boom":
                    SoundManager.PlaySound("item");
                    if (boom == maxBoom)
                        score += 500;
                    else{
                        boom++;
                        gameManager.UpdateBoomIcon(boom);
                    }
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }

    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
        isBoomTime = false;
    }

    void AddFollower()
    {
        if( power == 4)
            followers[0].SetActive(true);
        else if (power == 5)
            followers[1].SetActive(true);
        else if (power == 6)
            followers[2].SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border"){
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

}
