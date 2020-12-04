using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyBPrefab;
    public GameObject enemyB2Prefab;
    public GameObject enemyB3Prefab;

    public GameObject enemyLPrefab;
    public GameObject enemyL2Prefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;
    public GameObject enemyS2Prefab;
    public GameObject enemyS3Prefab;
    public GameObject enemyM2Prefab;
    public GameObject enemyRPrefab;
    public GameObject enemyR2Prefab;
    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;
    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletPlayerHPrefab;
    public GameObject bulletPlayerH2Prefab;
    public GameObject bulletPlayerWPrefab;
    public GameObject bulletPlayerW2Prefab;
    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletFollowerPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;
    public GameObject bulletLaserPrefab;
    public GameObject bulletLaser2Prefab;
    public GameObject explosionPrefab;


    GameObject[] enemyB;
    GameObject[] enemyB2;
    GameObject[] enemyB3;
    GameObject[] enemyL;
    GameObject[] enemyL2;
    GameObject[] enemyM;
    GameObject[] enemyS;
    GameObject[] enemyS2;
    GameObject[] enemyS3;
    GameObject[] enemyM2;
    GameObject[] enemyR;
    GameObject[] enemyR2;



    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletPlayerH;
    GameObject[] bulletPlayerH2;
    GameObject[] bulletPlayerW;
    GameObject[] bulletPlayerW2;
    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;
    GameObject[] bulletFollower;
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;
    GameObject[] bulletLaser;
    GameObject[] bulletLaser2;
    GameObject[] explosion;

    GameObject[] targetPool;

    void Awake()
    {
        enemyB = new GameObject[10];
        enemyB2 = new GameObject[10];
        enemyB3 = new GameObject[10];
        enemyL = new GameObject[10];
        enemyL2 = new GameObject[10];
        enemyM = new GameObject[10];
        enemyS = new GameObject[20];
        enemyS2 = new GameObject[20];
        enemyS3 = new GameObject[20];
        enemyM2 = new GameObject[20];
        enemyR = new GameObject[20];
        enemyR2 = new GameObject[20];

      
        
        itemCoin = new GameObject[20];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[100];
        bulletPlayerB = new GameObject[100];
        bulletPlayerH = new GameObject[100];
        bulletPlayerH2 = new GameObject[100];
        bulletPlayerW = new GameObject[100];
        bulletPlayerW2 = new GameObject[100];
        bulletEnemyA = new GameObject[100];
        bulletEnemyB = new GameObject[100];
        bulletFollower = new GameObject[100];
        bulletBossA = new GameObject[50];
        bulletBossB = new GameObject[1000];
        bulletLaser = new GameObject[100];
        bulletLaser2 = new GameObject[100];
        explosion = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        //Enemy
        for(int index=0; index < enemyB.Length; index++ ){
            enemyB[index] = Instantiate(enemyBPrefab);
            enemyB[index].SetActive(false);
        }

        for(int index=0; index < enemyB2.Length; index++ ){
            enemyB2[index] = Instantiate(enemyB2Prefab);
            enemyB2[index].SetActive(false);
        }

        for(int index=0; index < enemyB3.Length; index++ ){
            enemyB3[index] = Instantiate(enemyB3Prefab);
            enemyB3[index].SetActive(false);
        }

        for(int index=0; index < enemyL.Length; index++ ){
            enemyL[index] = Instantiate(enemyLPrefab);
            enemyL[index].SetActive(false);
        }

        for(int index=0; index < enemyL2.Length; index++ ){
            enemyL2[index] = Instantiate(enemyL2Prefab);
            enemyL2[index].SetActive(false);
        }

        for(int index=0; index < enemyM.Length; index++ ){
            enemyM[index] = Instantiate(enemyMPrefab);
            enemyM[index].SetActive(false);            
        }
        for(int index=0; index < enemyS.Length; index++ ){
            enemyS[index] = Instantiate(enemySPrefab);
            enemyS[index].SetActive(false);
        }
        for(int index=0; index < enemyS2.Length; index++ ){
            enemyS2[index] = Instantiate(enemyS2Prefab);
            enemyS2[index].SetActive(false);
        }

        for(int index=0; index < enemyS3.Length; index++ ){
            enemyS3[index] = Instantiate(enemyS3Prefab);
            enemyS3[index].SetActive(false);
        }

        for(int index=0; index < enemyM2.Length; index++ ){
            enemyM2[index] = Instantiate(enemyM2Prefab);
            enemyM2[index].SetActive(false);
        }
        for(int index=0; index < enemyR.Length; index++ ){
            enemyR[index] = Instantiate(enemyRPrefab);
            enemyR[index].SetActive(false);
        }

        for(int index=0; index < enemyR2.Length; index++ ){
            enemyR2[index] = Instantiate(enemyR2Prefab);
            enemyR2[index].SetActive(false);
        }



        //Item
        for(int index=0; index < itemCoin.Length; index++ ){
            itemCoin[index] = Instantiate(itemCoinPrefab);
            itemCoin[index].SetActive(false);
        }
        for(int index=0; index < itemPower.Length; index++ ){
            itemPower[index] = Instantiate(itemPowerPrefab);
            itemPower[index].SetActive(false);
        }

        for(int index=0; index < itemBoom.Length; index++ ){
            itemBoom[index] = Instantiate(itemBoomPrefab);
            itemBoom[index].SetActive(false);
        }

        //Bullet
        for(int index=0; index < bulletPlayerA.Length; index++ ){
            bulletPlayerA[index] = Instantiate(bulletPlayerAPrefab);
            bulletPlayerA[index].SetActive(false);
        }

        for(int index=0; index < bulletPlayerB.Length; index++ ){
            bulletPlayerB[index] = Instantiate(bulletPlayerBPrefab);
            bulletPlayerB[index].SetActive(false);
        }

        for(int index=0; index < bulletPlayerH.Length; index++ ){
            bulletPlayerH[index] = Instantiate(bulletPlayerHPrefab);
            bulletPlayerH[index].SetActive(false);
        }

        for(int index=0; index < bulletPlayerH2.Length; index++ ){
            bulletPlayerH2[index] = Instantiate(bulletPlayerH2Prefab);
            bulletPlayerH2[index].SetActive(false);
        }

        for(int index=0; index < bulletPlayerW.Length; index++ ){
            bulletPlayerW[index] = Instantiate(bulletPlayerWPrefab);
            bulletPlayerW[index].SetActive(false);
        }

        for(int index=0; index < bulletPlayerW2.Length; index++ ){
            bulletPlayerW2[index] = Instantiate(bulletPlayerW2Prefab);
            bulletPlayerW2[index].SetActive(false);
        }

        for(int index=0; index < bulletEnemyA.Length; index++ ){
            bulletEnemyA[index] = Instantiate(bulletEnemyAPrefab);
            bulletEnemyA[index].SetActive(false);
        }

        for(int index=0; index < bulletEnemyB.Length; index++ ){
            bulletEnemyB[index] = Instantiate(bulletEnemyBPrefab);
            bulletEnemyB[index].SetActive(false);
        }

        for(int index=0; index < bulletFollower.Length; index++ ){
            bulletFollower[index] = Instantiate(bulletFollowerPrefab);
            bulletFollower[index].SetActive(false);
        }

        for(int index=0; index < bulletBossA.Length; index++ ){
            bulletBossA[index] = Instantiate(bulletBossAPrefab);
            bulletBossA[index].SetActive(false);
        }

        for(int index=0; index < bulletBossB.Length; index++ ){
            bulletBossB[index] = Instantiate(bulletBossBPrefab);
            bulletBossB[index].SetActive(false);
        }

        for(int index=0; index < bulletLaser.Length; index++ ){
            bulletLaser[index] = Instantiate(bulletLaserPrefab);
            bulletLaser[index].SetActive(false);
        }

        for(int index=0; index < bulletLaser2.Length; index++ ){
            bulletLaser2[index] = Instantiate(bulletLaser2Prefab);
            bulletLaser2[index].SetActive(false);
        }

        for(int index=0; index < explosion.Length; index++ ){
            explosion[index] = Instantiate(explosionPrefab);
            explosion[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyB2":
                targetPool = enemyB2;
                break;
            case "EnemyB3":
                targetPool = enemyB3;
                break;
                
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyL2":
                targetPool = enemyL2;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "EnemyS2":
                targetPool = enemyS2;
                break;
            case "EnemyS3":
                targetPool = enemyS3;
                break;
            case "EnemyM2":
                targetPool = enemyM2;
                break;
            case "EnemyR":
                targetPool = enemyR;
                break;
            case "EnemyR2":
                targetPool = enemyR2;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletPlayerH":
                targetPool = bulletPlayerH;
                break;
            case "BulletPlayerH2":
                targetPool = bulletPlayerH2;
                break;
            case "BulletPlayerW":
                targetPool = bulletPlayerW;
                break;
            case "BulletPlayerW2":
                targetPool = bulletPlayerW2;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "BulletLaser":
                targetPool = bulletLaser;
                break;
            case "BulletLaser2":
                targetPool = bulletLaser2;
                break;
            case "Explosion":
                targetPool = explosion;
                break;
        }

        for (int index =0; index < targetPool.Length; index++){
            if(!targetPool[index].activeSelf){
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "EnemyB":
                targetPool = enemyB;
                break;
            case "EnemyB2":
                targetPool = enemyB2;
                break;
            case "EnemyB3":
                targetPool = enemyB3;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyL2":
                targetPool = enemyL2;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "EnemyS2":
                targetPool = enemyS2;
                break;
            case "EnemyS3":
                targetPool = enemyS3;
                break;
            case "EnemyM2":
                targetPool = enemyM2;
                break;
             case "EnemyR":
                targetPool = enemyR;
                break;
            case "EnemyR2":
                targetPool = enemyR2;
                break;

            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletPlayerH":
                targetPool = bulletPlayerH;
                break;
            case "BulletPlayerH2":
                targetPool = bulletPlayerH2;
                break;
            case "BulletPlayerW":
                targetPool = bulletPlayerW;
                break;
            case "BulletPlayerW2":
                targetPool = bulletPlayerW2;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletFollower":
                targetPool = bulletFollower;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "BulletLaser":
                targetPool = bulletLaser;
                break;
            case "BulletLaser2":
                targetPool = bulletLaser2;
                break;
            case "Explosion":
                targetPool = explosion;
                break;
        }
        return targetPool;
    }

}
