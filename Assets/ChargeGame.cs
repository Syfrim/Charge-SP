using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity C# Script for "Charge" Game Prototype
// Step 1: Setting Up the Unity Project
// 1. Create a new 2D Unity project.
// 2. Import necessary assets for buttons and stickman characters.
// 3. Set up the scene with UI elements and game logic components.

// Unity C# Script for "Charge" Game Prototype
// Fixed Step: Round Updates Every 5 Seconds

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeGame : MonoBehaviour
{
    // Game Variables
    private int playerHearts = 3;
    private int opponentHearts = 3;
    private int playerCharge = 0;
    private int opponentCharge = 0;
    private int roundNumber = 1;
    private bool playerLockedIn = false;
    private bool opponentLockedIn = false;
    private string playerChoice = "Charge";
    private string opponentChoice = "Charge";

    // UI Elements
    public TextMeshProUGUI playerHeartsText;
    public TextMeshProUGUI opponentHeartsText;
    public TextMeshProUGUI playerChargeText;
    public TextMeshProUGUI opponentChargeText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;
    public Button chargeButton;
    public Button attackButton;
    public Button defendButton;
    public Button skill1Button;
    public Button skill2Button;

    // Timer
    private float timer = 5f;
    private bool roundActive = true;

    void Start()
    {
        UpdateUI();
        resultText.text = "";
        chargeButton.onClick.AddListener(() => PlayerChoice("Charge"));
        attackButton.onClick.AddListener(() => PlayerChoice("Attack"));
        defendButton.onClick.AddListener(() => PlayerChoice("Defend"));
        skill1Button.onClick.AddListener(() => PlayerChoice("Skill 1"));
        skill2Button.onClick.AddListener(() => PlayerChoice("Skill 2"));
    }

    void Update()
    {
        if (roundActive)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                ProcessRound();
                roundNumber++; // Increment round number
                Debug.Log("Round Number: " + roundNumber); // Debug check
                timer = 5f; // Reset timer explicitly after processing the round
                UpdateUI(); // Update UI to reflect the new round number
            }
        }
    }


    void PlayerChoice(string choice)
    {
        if (!playerLockedIn)
        {
            playerChoice = choice;
            playerLockedIn = true;
        }
    }

    void OpponentChoice()
    {
        switch (roundNumber % 11)
        {
            case 1: case 4: case 5: case 6: case 8: case 9: case 10:
                opponentChoice = "Charge";
                break;
            case 2:
                opponentChoice = "Attack";
                break;
            case 3:
                opponentChoice = "Defend";
                break;
            case 7:
                opponentChoice = "Skill 1";
                break;
            case 0:
                opponentChoice = "Skill 2";
                break;
        }
        opponentLockedIn = true;
    }

    void ProcessRound()
    {
        roundActive = false;
        OpponentChoice();

        if (!playerLockedIn)
            playerChoice = "Charge";

        // Handle insufficient charges for player
        if ((playerChoice == "Attack" && playerCharge < 1) || 
            (playerChoice == "Skill 1" && playerCharge < 3) || 
            (playerChoice == "Skill 2" && playerCharge < 3))
        {
            playerChoice = "Charge"; // Treat as a "Charge" move
        }

        // Handle insufficient charges for opponent
        if ((opponentChoice == "Attack" && opponentCharge < 1) || 
            (opponentChoice == "Skill 1" && opponentCharge < 3) || 
            (opponentChoice == "Skill 2" && opponentCharge < 3))
        {
            opponentChoice = "Charge"; // Treat as a "Charge" move
        }

        // Game Logic for Resolving Choices
        if (playerChoice == "Attack" && opponentChoice == "Attack")
        {
            // Both use Attack, they cancel each other out
            if (playerCharge > 0) playerCharge--;
            if (opponentCharge > 0) opponentCharge--;
        }
        else if (playerChoice == "Attack" && opponentChoice == "Skill 1")
        {
            // Attack blocks Skill 1
            if (playerCharge > 0) playerCharge--;
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Attack")
        {
            // Skill 1 blocks Attack
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge > 0) opponentCharge--;
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Attack")
        {
            // Skill 2 blocks Attack
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge > 0) opponentCharge--;
        }
        else if (playerChoice == "Attack" && opponentChoice == "Skill 2")
        {
            // Skill 2 blocks Attack, and player takes damage
            if (playerCharge > 0) playerCharge--;
            playerHearts--; // Player takes damage
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Skill 2")
        {
            // Skill 1 blocked by Skill 2
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Skill 1")
        {
            // Skill 2 blocks Skill 1
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Skill 1")
        {
            // Both use Skill 1, they cancel each other out
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Skill 2")
        {
            // Both use Skill 2, they cancel each other out
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else
        {
            // Default logic for unblocked moves
            if (playerChoice == "Attack")
            {
                if (playerCharge > 0)
                {
                    playerCharge--;
                    if (opponentChoice != "Defend") opponentHearts--;
                }
            }
            else if (opponentChoice == "Attack")
            {
                if (opponentCharge > 0)
                {
                    opponentCharge--;
                    if (playerChoice != "Defend") playerHearts--;
                }
            }
            else if (playerChoice == "Skill 1")
            {
                if (playerCharge >= 3)
                {
                    playerCharge -= 3;
                    if (opponentChoice != "Skill 1" && opponentChoice != "Attack") opponentHearts--;
                }
            }
            else if (opponentChoice == "Skill 1")
            {
                if (opponentCharge >= 3)
                {
                    opponentCharge -= 3;
                    if (playerChoice != "Skill 1" && playerChoice != "Attack") playerHearts--;
                }
            }
            else if (playerChoice == "Skill 2")
            {
                if (playerCharge >= 3)
                {
                    playerCharge -= 3;
                    if (opponentChoice != "Skill 2") opponentHearts--;
                }
            }
            else if (opponentChoice == "Skill 2")
            {
                if (opponentCharge >= 3)
                {
                    opponentCharge -= 3;
                    if (playerChoice != "Skill 2") playerHearts--;
                }
            }
        }

        if (playerChoice == "Charge") playerCharge++; // Increment charge when choosing to charge
        if (opponentChoice == "Charge") opponentCharge++; // Increment opponent charge similarly

        CheckGameOver();
        ResetRound();
    }




    void UpdateUI()
    {
        playerHeartsText.text = "Hearts: " + playerHearts;
        opponentHeartsText.text = "Hearts: " + opponentHearts;
        playerChargeText.text = "Charge: " + playerCharge;
        opponentChargeText.text = "Charge: " + opponentCharge;
        roundText.text = "Round: " + roundNumber;
    }

    void ResetRound()
    {
        roundActive = true;
        playerLockedIn = false;
        opponentLockedIn = false;
        playerChoice = "Charge";
        opponentChoice = "Charge";
    }

    void CheckGameOver()
    {
        if (playerHearts <= 0 || opponentHearts <= 0 || roundNumber >= 100)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        roundActive = false;

        if (playerHearts <= 0)
        {
            resultText.text = "DEFEAT";
        }
        else if (opponentHearts <= 0)
        {
            resultText.text = "VICTORY";
        }
        else if (roundNumber >= 100)
        {
            resultText.text = "TIE GAME";
        }
    }


        // Add these methods to the existing ChargeGame script

    public void OnChargeButton()
    {
        PlayerChoice("Charge");
    }

    public void OnAttackButton()
    {
        PlayerChoice("Attack");
    }

    public void OnDefendButton()
    {
        PlayerChoice("Defend");
    }

    public void OnSkill1Button()
    {
        PlayerChoice("Skill 1");
    }

    public void OnSkill2Button()
    {
        PlayerChoice("Skill 2");
    }

}
