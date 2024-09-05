using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 黑洞技能热键控制，放在热键的预制件里实现对热键的行为控制
public class BlackholeHotkeyController : MonoBehaviour
{

    private SpriteRenderer sr;
    private KeyCode myHotkey;
    private TextMeshProUGUI myText;

    private Transform myEnemy;
    private BlackholeSkillController blackhole;

    public void SetupHotkey(KeyCode _myHotkey, Transform _myEnemy, BlackholeSkillController _myBlackhole)
    {
        sr = GetComponent<SpriteRenderer>();
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myEnemy = _myEnemy;
        blackhole = _myBlackhole;

        myHotkey = _myHotkey;
        myText.text = myHotkey.ToString();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(myHotkey))
        {
            blackhole.AddEnemyToList(myEnemy);
            myText.color = Color.clear;
            sr.color = Color.clear;
        }
    }

}
