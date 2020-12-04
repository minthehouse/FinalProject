using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int stage;
    public Animator stageAnim;
    public Animator clearAnim;
    public Animator fadeAnim;
    public Transform playerPos;

    public string[] enemyObjs;
    public Transform[] spawnPoints;

    public float nextSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public Text scoreText;
    public Image[] lifeImage;
    public Image[] boomImage;
    public GameObject gameOverSet;
    public ObjectManager objectManager;

    public List<Spawn> spawnList;
    public int spawnIndex;
    public bool spawnEnd;

    private Scene scene;

    void Awake()
    {
        spawnList = new List<Spawn>();
        enemyObjs = new string[] { "EnemyS", "EnemyM", "EnemyL", "EnemyB", "EnemyS2", "EnemyM2", "EnemyR", "EnemyB2", "EnemyS3", "EnemyL2", "EnemyR2", "EnemyB3" };
        StageStart();
    }

    public void StageStart()
    {

        //Stage UI Load
        stageAnim.SetTrigger("On");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[1]Stage2"))
            stage++;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[1]Stage3"))
            stage = stage + 2;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[2]Stage2"))
            stage++;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[2]Stage3"))
            stage = stage + 2;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[3]Stage2"))
            stage++;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[3]Stage3"))
            stage = stage + 2;

        stageAnim.GetComponent<Text>().text = "STAGE " + stage + "\nSTART";
        clearAnim.GetComponent<Text>().text = "STAGE " + stage + "\nCLEAR";


        //Enemy Spawn File Read
        ReadSpawnFile();

        //Fade In
        fadeAnim.SetTrigger("In");
    }

    public void StageEnd()
    {
        //Clear UI Load
        clearAnim.SetTrigger("On");

        //Fade Out
        fadeAnim.SetTrigger("Out");

        //Player Repos
        //player.transform.position = playerPos.position;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[1]Stage1"))
            SceneManager.LoadScene("[1]Stage2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[1]Stage2"))
            SceneManager.LoadScene("[1]Stage3");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[2]Stage1"))
            SceneManager.LoadScene("[2]Stage2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[2]Stage2"))
            SceneManager.LoadScene("[2]Stage3");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[3]Stage1"))
            SceneManager.LoadScene("[3]Stage2");

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("[3]Stage2"))
            SceneManager.LoadScene("[3]Stage3");

        //Stage Increasement
        stage++;
        if (stage > 2)                        //Depending on the number of stages, end game or keep going !
            Invoke("GameOver", 6);
        else
            Invoke("StageStart", 5);
    }

    void ReadSpawnFile()
    {
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        TextAsset textFile = Resources.Load("Stage " + stage) as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            Debug.Log(line);

            if (line == null)
                break;

            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split(',')[0]);
            spawnData.type = line.Split(',')[1];
            spawnData.point = int.Parse(line.Split(',')[2]);
            spawnList.Add(spawnData);
        }

        stringReader.Close();

        nextSpawnDelay = spawnList[0].delay;

    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > nextSpawnDelay && !spawnEnd)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        }

        //UI Score Update
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);
    }



    void SpawnEnemy()
    {
        int enemyIndex = 0;
        switch (spawnList[spawnIndex].type)
        {
            case "S":
                enemyIndex = 0;
                break;
            case "M":
                enemyIndex = 1;
                break;
            case "L":
                enemyIndex = 2;
                break;
            case "B":
                enemyIndex = 3;
                break;
            case "S2":
                enemyIndex = 4;
                break;
            case "M2":
                enemyIndex = 5;
                break;
            case "R":
                enemyIndex = 6;
                break;
            case "B2":
                enemyIndex = 7;
                break;
            case "S3":
                enemyIndex = 8;
                break;
            case "L2":
                enemyIndex = 9;
                break;
            case "R2":
                enemyIndex = 10;
                break;
            case "B3":
                enemyIndex = 11;
                break;

        }


        int enemyPoint = spawnList[spawnIndex].point;
        GameObject enemy = objectManager.MakeObj(enemyObjs[enemyIndex]);
        enemy.transform.position = spawnPoints[enemyPoint].position;

        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;
        enemyLogic.gameManager = this;
        enemyLogic.objectManager = objectManager;

        if (enemyPoint == 5 || enemyPoint == 6)
        {            //Right Spawn
            enemy.transform.Rotate(Vector3.back * 90);
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
        }
        else if (enemyPoint == 7 || enemyPoint == 8)
        {       //Left Spawn
            enemy.transform.Rotate(Vector3.forward * 90);
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
        }
        else
        {      // Front Spawn
            rigid.velocity = new Vector2(0, enemyLogic.speed * (-1));
        }

        spawnIndex++;
        if (spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

        nextSpawnDelay = spawnList[spawnIndex].delay;
    }

    public void UpdateLifeIcon(int life)
    {
        //UI Life Init Disable
        for (int index = 0; index < 3; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 0);
        }

        //UI Life Active
        for (int index = 0; index < life; index++)
        {
            lifeImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void UpdateBoomIcon(int boom)
    {
        //UI Boom Init Disable
        for (int index = 0; index < 3; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 0);
        }

        //UI Boom Active
        for (int index = 0; index < boom; index++)
        {
            boomImage[index].color = new Color(1, 1, 1, 1);
        }
    }

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerExe", 2f);
    }

    void RespawnPlayerExe()
    {
        player.transform.position = Vector3.down * 3.5f;
        player.SetActive(true);

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.isHit = false;
    }

    public void CallExplosion(Vector3 pos, string type)
    {
        GameObject explosion = objectManager.MakeObj("Explosion");
        Explosion explosionLogic = explosion.GetComponent<Explosion>();

        explosion.transform.position = pos;
        explosionLogic.StartExplosion(type);
    }

    public void GameOver()
    {
        gameOverSet.SetActive(true);
    }

    public void GameRetry()
    {
        if (SceneManager.GetActiveScene().buildIndex % 3 == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (SceneManager.GetActiveScene().buildIndex % 3 == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (SceneManager.GetActiveScene().buildIndex % 3 == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }


}
