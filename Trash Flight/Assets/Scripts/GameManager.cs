using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    

    private int coin = 0;

    [HideInInspector]
    public bool isGameOver = false;

    void Awake() {
        if(!instance){
            instance = this;
        }    
    }


    public void IncreaseCoin(){
        coin++;
        text.SetText(coin.ToString());

        if(coin % 20 == 0){
            Player player = FindObjectOfType<Player>();

            if(player){
                player.UpgradeWeapon();
            }
        }
    }

    public void SetGameOver(){
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();

        if(enemySpawner){
            enemySpawner.StopEnemyRoutine();
        }

        isGameOver = !isGameOver;


        Invoke("ShowGameOverPanel", 1f);

    }

    void ShowGameOverPanel(){
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("SampleScene");
    }
}
