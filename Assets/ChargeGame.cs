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


using UnityEngine.UI;
using TMPro;

public class ChargeGame : MonoBehaviour
{

    public ButtonHighlightManager buttonHighlightManager;

    private bool debugMode = false;
    private string forcedOpponentChoice = "Charge";
    void ToggleDebugMode()
    {
        debugMode = !debugMode;
        Debug.Log($"Debug Mode: {(debugMode ? "ON" : "OFF")} - Opponent will {(debugMode ? "always charge" : "act normally")}");
    }


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
    public TextMeshProUGUI opponentMoveText;
   
    public GameObject resultBackground;
    public GameObject damageScreen;
    
    public AudioSource damageSound;
    public AudioSource attackSound;
    public AudioSource chargeSound;
    public AudioSource defendSound;
    public AudioSource breakSound;
    public AudioSource blockSound;
    public AudioSource explosionSound;
    public AudioSource skill1Sound;
    public AudioSource skill2Sound;
    public AudioSource NightBorneDeathSound;
    public AudioSource NightBorneDefendSound;

    public Button chargeButton;
    public Button attackButton;
    public Button defendButton;
    public Button skill1Button;
    public Button skill2Button;
    public Button playAgainButton;

    

    public Animator playerAnimator;
    public Animator effectAnimator;

   

    

    // Timer
    private float timer = 3f;
    private bool roundActive = true;
    private float damageScreenTimer = 0f;
    
    
    void ShowEndGameScreen(string result)
    {
        resultText.text = result;
        resultBackground.SetActive(true);
    }

    void UpdateOpponentMoveText(string move)
    {
        if (opponentMoveText != null)
        {
            opponentMoveText.text = $"Opponent used {move}!";
        }
    }

    void HandleAttack(bool isPlayerAttack)
    {
        if (isPlayerAttack)
        {
            if (opponentChoice != "Defend" && opponentChoice != "Skill 1" && opponentChoice != "Attack")
            {
            
                opponentHearts--;
                if (attackSound != null)
                {
                    Debug.Log("Playing attackSound");
                    attackSound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Attack");
                }

                
                else
                {
                    Debug.LogWarning("attackSound is not assigned!");
                }
            }

            else
            {
                if (attackSound != null)
                {
                    Debug.Log("Playing attackSound");
                    attackSound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Attack");
                } 
            }
        }  
    }

    void PlayNightBorneDeathSound()
    {
        if (NightBorneDeathSound != null)
        {
            NightBorneDeathSound.Play(); // Play the defend sound effect
        }
    }
    void PlayNightBorneDefendSound()
    {
        if (NightBorneDefendSound != null)
        {
            NightBorneDefendSound.Play(); // Play the defend sound effect
        }
    }
    void PlayDefendSound()
    {
        if (defendSound != null)
        {
            defendSound.Play(); // Play the defend sound effect
        }
    }

    void PlayBreakSound()
    {
        if (breakSound != null)
        {
            breakSound.Play(); // Play the break sound effect
        }
    }

    void PlayBlockSound()
    {
        if (blockSound != null)
        {
            blockSound.Play(); // Play the block sound effect
        }
    }

    void PlayExplosionSound()
    {
        if (explosionSound != null)
        {
            explosionSound.Play(); // Play the block sound effect
        }
    }

    void PlaySkill1Sound()
    {
        if (skill1Sound != null)
        {
            skill1Sound.Play(); // Play the sound effect for Skill 1
        }
    }
    void PlaySkill2Sound()
    {
        if (skill2Sound != null)
        {
            skill2Sound.Play(); // Play the sound effect for Skill 1
        }
    }

   

    void HandleSkill2(bool isPlayerSkill2)
    {
        if (isPlayerSkill2)
        {
            if (opponentChoice != "Defend" && opponentChoice != "Skill 1")
            {
            
                opponentHearts--;
                if (skill2Sound != null)
                {
                    Debug.Log("Playing attackSound");
                    skill2Sound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Skill_2");
                }
                if (effectAnimator != null)
                {
                    effectAnimator.SetTrigger("Skill_2_Explosion");
                }

                
                else
                {
                    Debug.LogWarning("attackSound is not assigned!");
                }
            }

            else
            {
                if (skill2Sound != null)
                {
                    Debug.Log("Playing attackSound");
                    skill2Sound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Skill_2");
                } 
            }
        } 
    }

    void HandleSkill1(bool isPlayerSkill1)
    {
        if (isPlayerSkill1)
        {
            if (opponentChoice != "Attack" && opponentChoice != "Skill 1")
            {
            
                opponentHearts--;
                if (skill1Sound != null)
                {
                    Debug.Log("Playing attackSound");
                    skill1Sound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Skill_1");
                }
                if (effectAnimator != null)
                {
                    effectAnimator.SetTrigger("Skill_1_Explosion");
                }

                
                else
                {
                    Debug.LogWarning("attackSound is not assigned!");
                }
            }

            else
            {
                if (skill1Sound != null)
                {
                    Debug.Log("Playing attackSound");
                    skill1Sound.Play();
                }
                if (playerAnimator != null)
                {
                    // Trigger the attack animation
                    playerAnimator.SetTrigger("Skill_1");
                } 
            }
        } 
    }

    void HandleDefend(bool isPlayerDefend)
    {
        if (isPlayerDefend)
        {
            

            if (playerAnimator != null)
            {
                // Trigger the attack animation
                playerAnimator.SetTrigger("Defend");
            }
            if (NightBorneDefendSound != null)
            {
                Debug.Log("Playing skill1Sound");
                NightBorneDefendSound.Play();
            }
        
            
            
           
            
            else
            {
                Debug.LogWarning("defend is not assigned!");
            }
        }
    }

    void Start()
    {
        UpdateUI();
        resultText.text = "";
        chargeButton.onClick.AddListener(() => PlayerChoice("Charge"));
        attackButton.onClick.AddListener(() => PlayerChoice("Attack"));
        defendButton.onClick.AddListener(() => PlayerChoice("Defend"));
        skill1Button.onClick.AddListener(() => PlayerChoice("Skill 1"));
        skill2Button.onClick.AddListener(() => PlayerChoice("Skill 2"));
        resultBackground.SetActive(false);
        damageScreen.SetActive(false);
        playAgainButton.gameObject.SetActive(false);

        // Add a listener to restart the game
        playAgainButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleDebugMode();
        }
        if (roundActive)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                timer = 0; // Prevent negative values
            
                roundActive = false;
                ProcessRound();
                roundNumber++; // Increment round number
                Debug.Log("Round Number: " + roundNumber); // Debug check
                timer = 3f; // Reset timer explicitly after processing the round
                UpdateUI(); // Update UI to reflect the new round number
            }
        }

        if (damageScreenTimer > 0)
        {
                damageScreenTimer -= Time.deltaTime;
                if (damageScreenTimer <= 0)
                {
                    damageScreen.SetActive(false); // Turn off damage screen after 0.3 seconds
                }
        }
        
    }


    void PlayerChoice(string choice)
    {
        if (!playerLockedIn)
        {
            playerChoice = choice;
            playerLockedIn = true;

            if (choice == "Attack")
                buttonHighlightManager.HighlightButton(attackButton);
            else if (choice == "Charge")
                buttonHighlightManager.HighlightButton(chargeButton);
            else if (choice == "Defend")
                buttonHighlightManager.HighlightButton(defendButton);
            else if (choice == "Skill 1")
                buttonHighlightManager.HighlightButton(skill1Button);
            else if (choice == "Skill 2")
                buttonHighlightManager.HighlightButton(skill2Button);

        }
    }

    void OpponentChoice()
    {   
        if (debugMode)
        {
            opponentChoice = forcedOpponentChoice;
            return;
        }
        if (roundNumber == 1)
        {
            // Always "Charge" on the first round
            opponentChoice = "Charge";
        }
        else
        {
            int randomFactor = Random.Range(1, 4); // Randomly adjusts decision
            switch ((roundNumber + randomFactor) % 11)
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
            
            if (opponentCharge == 0)
            {
                float skillProbability = Random.value; 
                if (skillProbability < 0.6f)
                {
                    opponentChoice = "Charge";
                }
                else
                {
                    opponentChoice = "Defend";
                }
            }

            if (opponentCharge >= 3)
            {
                // Randomly decide between Skill 1 and Skill 2
                float skillProbability = Random.value; 
                if (skillProbability < 0.4f)
                {
                    opponentChoice = "Skill 1";
                }
                else if (skillProbability < 0.8f)
                {
                    opponentChoice = "Skill 2";
                }
                else 
                {
                    opponentChoice = "Attack";
                }
            }
            else if (playerCharge == opponentCharge)
            {
                // Random choice between Attack, Defend, and Charge
                float equalChargeProbability = Random.value;
                if (equalChargeProbability < 0.4f)
                {
                    opponentChoice = "Attack";
                }
                else if (equalChargeProbability < 0.6f)
                {
                    opponentChoice = "Defend";
                }
                else
                {
                    opponentChoice = "Charge";
                }
            }
            else if (playerCharge > opponentCharge && Random.value > 0.7f)
            {
                opponentChoice = "Defend"; // Defensive strategy if player has an advantage
            }
            else if (playerCharge > opponentCharge && Random.value > 0.6f)
            {
                opponentChoice = "Charge";
            }
            else if (playerCharge >= 3 && Random.value > 0.5f)
            {
                opponentChoice = "Attack";
            }
            else if (playerCharge < opponentCharge && Random.value > 0.6f)
            {
                opponentChoice = "Attack";
            }
            else
            {
                opponentChoice = "Charge"; // Default action to gain resources
            }
        }

        UpdateOpponentMoveText(opponentChoice);

        opponentLockedIn = true;
    }




    void ProcessRound()
    {
        roundActive = false;
        OpponentChoice();
        int previousHearts = playerHearts;

        

        if (!playerLockedIn)
            playerChoice = "Charge";

         // Game Logic for Resolving Choices
        if (playerChoice == "Attack" && opponentChoice == "Defend")
        {
            PlayDefendSound();
            HandleAttack(true);

        }
        else if (opponentChoice == "Attack" && playerChoice == "Defend")
        {
            PlayDefendSound();
            HandleDefend(true);
        }
        else if (opponentChoice == "Defend" && playerChoice == "Defend")
        {
    
            HandleDefend(true);
        }
        else if (opponentChoice == "Charge" && playerChoice == "Defend")
        {
            
            HandleDefend(true);
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Defend")
        {
            PlayBreakSound();
            HandleSkill1(true);
        }
        else if (opponentChoice == "Skill 1" && playerChoice == "Defend")
        {
            PlayBreakSound();
            HandleDefend(true);
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Defend")
        {
            PlayDefendSound();
            HandleSkill2(true);
        }
        else if (opponentChoice == "Skill 2" && playerChoice == "Defend")
        {
            PlayDefendSound();
            HandleDefend(true);
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Attack")
        {
            PlayBreakSound();
            HandleSkill2(true);
        }
        else if (opponentChoice == "Skill 2" && playerChoice == "Attack")
        {
            PlayBreakSound();
            HandleAttack(true);
        }
        else if (playerChoice == "Attack" && opponentChoice == "Attack")
        {
            PlayBlockSound();
            HandleAttack(true); // Block sound for Attack vs. Attack
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Skill 1")
        {
            PlayExplosionSound();
            HandleSkill1(true); // Block sound for Skill 1 vs. Skill 1
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Skill 2")
        {
            PlayBlockSound();
            HandleSkill2(true); // Block sound for Skill 2 vs. Skill 2
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Skill 2")
        {
            PlayBlockSound();
            HandleSkill1(true); // Block sound for Skill 1 vs. Skill 2
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Skill 1")
        {
            PlayBlockSound();
            HandleSkill2(true); // Block sound for Skill 2 vs. Skill 1
        }
        else if (playerChoice == "Skill 1" && opponentChoice == "Attack")
        {
            PlayExplosionSound();
            HandleSkill1(true); // Block sound for Skill 1 vs. Attack
        }
        else if (playerChoice == "Attack" && opponentChoice == "Skill 1")
        {
            PlayExplosionSound();
            HandleAttack(true); // Block sound for Attack vs. Skill 1
        }
        
    
        if (playerChoice == "Skill 1" && opponentChoice != "Skill 1" && opponentChoice != "Attack")
            {
                PlaySkill1Sound();
                
            }     
            else if (opponentChoice == "Skill 1" && playerChoice != "Skill 1" && playerChoice != "Attack")
            {
                PlaySkill1Sound();
                
            }
        if (playerChoice == "Skill 2" && opponentChoice != "Skill 2" && opponentChoice != "Defend")
            {
                PlaySkill2Sound();
            }     
            else if (opponentChoice == "Skill 2" && playerChoice != "Skill 2" && playerChoice != "Defend")
            {
                PlaySkill2Sound();
            }
        


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
            // Skill 2 breaks Attack
            if (playerCharge >= 3) playerCharge -= 3;
            if (opponentCharge > 0) opponentCharge--;
            opponentHearts--;
        }
        else if (playerChoice == "Attack" && opponentChoice == "Skill 2")
        {
            // Skill 2 blocks Attack, and player takes damage
            if (playerCharge > 0) playerCharge--;
            if (opponentCharge >= 3) opponentCharge -= 3;
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
        else if (playerChoice == "Defend" && opponentChoice == "Skill 2")
        {
            // Defend blocks skill 2
            
            if (opponentCharge >= 3) opponentCharge -= 3;
        }
        else if (playerChoice == "Skill 2" && opponentChoice == "Defend")
        {
            // Defend blocks skill 2
            
            if (playerCharge >= 3) playerCharge -= 3;
        }

        
        else
        {
            // Default logic for unblocked moves
            if (playerChoice == "Attack")
            {
                if (playerCharge > 0)
                {
                    playerCharge--;
                    if (opponentChoice != "Defend")
                    {
                        HandleAttack(true); // Call the method to reduce hearts and play sound
                    }
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
                    if (opponentChoice != "Skill 1" && opponentChoice != "Attack")
                    {
                        HandleSkill1(true);
                    }
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
                    if (opponentChoice != "Skill 2" && opponentChoice != "Defend")  
                    {
                        
                        HandleSkill2(true); // Call the method to reduce hearts and play sound
                    
                    }

                }
            }

        
            else if (opponentChoice == "Skill 2")
            {
                if (opponentCharge >= 3)
                {
                    opponentCharge -= 3;
                    if (playerChoice != "Skill 2" && playerChoice != "Defend") playerHearts--;
                }
            }
        }

        if (playerChoice == "Charge")  
        {
            playerCharge++;
            if (chargeSound != null)
            {
                chargeSound.Play();
                playerAnimator.SetTrigger("Charge");
            }
            else
            {
                Debug.LogWarning("ChargeSound is not assigned!");
            } 
        }// Increment charge when choosing to charge
        if (opponentChoice == "Charge") opponentCharge++; // Increment opponent charge similarly

    
        if (playerHearts < previousHearts)
        {
            damageScreen.SetActive(true);
            damageScreenTimer = 0.3f; // Start timer for 0.3 seconds
            playerAnimator.SetTrigger("Damage Taken");
            if (damageSound != null) 
            {
                damageSound.PlayOneShot(damageSound.clip);
                

            }
        }

        
        
        CheckGameOver();
        ResetRound();
        buttonHighlightManager.End();
        
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
        if (playerHearts <= 0)
        {
            playerAnimator.SetTrigger("Death");
            PlayNightBorneDeathSound();
            StartCoroutine(DelayedShowEndGameScreen("DEFEAT"));
        }
        else if (opponentHearts <= 0)
        {
            StartCoroutine(DelayedShowEndGameScreen("VICTORY"));
        }
        else if (roundNumber >= 100)
        {
            StartCoroutine(DelayedShowEndGameScreen("TIE GAME"));
        }
    }

    private IEnumerator DelayedShowEndGameScreen(string result)
    {
        yield return new WaitForSeconds(2.25f); // Wait for 3 seconds
        ShowEndGameScreen(result);
        playAgainButton.gameObject.SetActive(true);
        FindObjectOfType<EndGameManager>().ShowEndGameScreen();
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

    private void TriggerAnimation()
    {
        // Existing logic for ending the round...

        // Check if the player attacked this round
        if (playerChoice == "Attack")
        {
            // Trigger the attack animation
            playerAnimator.SetTrigger("Attack");
          
        }

        if (playerChoice == "Skill 2")
        {
            // Trigger the attack animation
            playerAnimator.SetTrigger("Skill_2");
          
        }
        

        // Reset or transition back to default after some delay
        StartCoroutine(ResetToIdleAnimation());
    }

    

    private IEnumerator ResetToIdleAnimation()
    {
        yield return new WaitForSeconds(4.0f); // Adjust delay as needed
        playerAnimator.SetTrigger("Idle");
        // Optionally, trigger idle animation explicitly
        // playerAnimator.SetTrigger("Idle");
    }

    private void ResetTriggers()
    {
        playerAnimator.ResetTrigger("Attack");
        playerAnimator.ResetTrigger("Skill_2");
        playerAnimator.ResetTrigger("Skill_1");
    }

    void RestartGame()
    {
        // Reset all game variables and UI for a new game
        playerHearts = 3;
        opponentHearts = 3;
        playerCharge = 0;
        opponentCharge = 0;
        roundNumber = 1;
        playerLockedIn = false;
        opponentLockedIn = false;
        timer = 5f;
        roundActive = true;

        // Hide the result UI and button
        resultBackground.SetActive(false);
        playAgainButton.gameObject.SetActive(false);

        // Clear result text
        resultText.text = "";

        // Reset UI elements
        UpdateUI();
    }

}
