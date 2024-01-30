using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameState", menuName = "State/MyGameState")]
public class GameState : ScriptableObject
{
    public int totalLives;

    public int score;
    public bool isImmune;
    public string playerName;

    public bool hasPitchfork;
    public bool hasGun;

    public int pitchforkDurability;
    public int gunDurability;

    //public GameObject currentWeapon;




    ///////////////////////////////////////////////////////////

    public int knowledgeScore;
    public int browniePoints;
    public int minimumKnowledgeNeeded;

    public int maxKnowledge;

    
    public bool isSwarmed;
    public bool isFrozen;
    public bool immune;

   








}
