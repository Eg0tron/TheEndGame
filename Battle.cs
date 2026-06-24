namespace CsharpLearning;

public class Battle
{
    public int CountOfRounds { get; private set; }
    public Player? CurrentPlayer { get; private set; }
    public void StartBattle(params List<Party> aliveParties)
    {
        while (true)
        {
            CountOfRounds++;
            Console.WriteLine($"Round {CountOfRounds}\n");

            foreach (Party party in aliveParties)
            {
                
                if (!party.IsAlive) continue;

                party.BelongsTo.IsPlayerTurn = true;
                CurrentPlayer = party.BelongsTo;

                Console.WriteLine($"It is {party.BelongsTo.Name}'s turn\n");

                foreach (Character currentCharacter in party._charactersParty)
                {
                    if (!currentCharacter.IsAlive) continue;

                    currentCharacter.IsCharacterTurn = true;
                    Console.WriteLine($"It is {currentCharacter.CharacterName}'s turn\n");

                    try // needed if a player will mess up with a number of a target 
                    {
                        CurrentPlayer.PickActionAndDo(aliveParties, currentCharacter, CurrentPlayer);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"{currentCharacter.CharacterName} did nothing");
                    }

                    Console.WriteLine();
                    currentCharacter.IsCharacterTurn = false;

                    CheckCharacterAndPartyDeath(aliveParties);

                    if (BattleEndCheck(aliveParties)) return;

                }

                DeleteDeadCharacter(aliveParties);
                

                
                Console.WriteLine("-------------------------------------------------\n");

                party.BelongsTo.IsPlayerTurn = false;

                Thread.Sleep(0);
            }

            DeleteDeadParties(aliveParties);
        }
    }

    private bool BattleEndCheck(List<Party> parties)
    {
        bool heroesAreAlive = false;
        bool monstersAreAlive = false;

        foreach (Party currentParty in parties)
        {
            if (heroesAreAlive && monstersAreAlive) break;

            if (currentParty.AreMonstersParty && currentParty.IsAlive) monstersAreAlive = true;
            else if (!currentParty.AreMonstersParty && currentParty.IsAlive) heroesAreAlive = true;
        }

        if (heroesAreAlive && monstersAreAlive) return false;
        else
        {
            if (heroesAreAlive) OutputSystem.WinMessage();
            else OutputSystem.LoseMessage();

            return true;
        }
    }

    private void DeleteDeadParties(List<Party> parties)
    {
        List<Party> partiesToDelete = new List<Party>();

        foreach (Party party in parties)
        {
            if (!party.IsAlive) partiesToDelete.Add(party);        
        }

        if (partiesToDelete.Count > 0)
        {
            foreach (Party party in partiesToDelete) parties.Remove(party);
        }
    }

    private void DeleteDeadCharacter(List<Party> parties)
    {
        List<(Party, Character)> charactersToDelete = new List<(Party, Character)>();

        foreach (Party party in parties)
        {
            foreach (Character character in party._charactersParty)
            {
                if (!character.IsAlive) charactersToDelete.Add((party, character));
            }
        }

        foreach ((Party p, Character c) character in charactersToDelete) character.p._charactersParty.Remove(character.c);
    }

    private void CheckCharacterAndPartyDeath(List<Party> parties)
    {
        foreach (Party party in parties)
        {
            if (!party.IsAlive) continue;
            
            int charactersInParty = 0;


            foreach (Character character in party._charactersParty)
            {
                if (!character.IsAlive) continue;
                else if (character.CurrentHP <= 0)
                {
                    character.IsAlive = false;
                    OutputSystem.CharacterDefeat(character);
                }
                else charactersInParty++;
            }

            if (charactersInParty == 0)
            {
                party.IsAlive = false;
                OutputSystem.PartyDefeat(party);
            }
        }
    }
}

