using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    public class Epilogue
    {
        private SaveData SaveData { get; set; }

        public Epilogue(SaveData saveData)
        {
            SaveData = saveData;
        }

        public static void PierreIsTheMurderer()
        {
            Console.WriteLine("\nPierre's eyes widen.");
            Console.WriteLine("Pierre > What!? No! I, I didn't, I-");
            Console.WriteLine("Abigail > Dad! If it wasn't you why did you ask me to lie for you?");
            Console.WriteLine("Pierre > I... Fine! Yes, I did it! I killed the old man, he was going to ruin this town!");
            Console.WriteLine("Pierre points at Morris");
            Console.WriteLine("Pierre > He was going to sell the Community Centre to HIM, so Joja can worm its way into every single part of our lives!");
            Console.WriteLine("Pierre > I was trying to save us...");
            Console.WriteLine("Caroline is crying. You notice the Wizard comforting her.");
            Console.WriteLine("Me > Pierre, you're under arrest. I think you'd better come with me.");
            Console.WriteLine("Pierre slumps, then sighs.");
            Console.WriteLine("Pierre > Fine. I was really trying to help though...");
        }

        public static void MarnieIsTheMurderer()
        {
            Console.WriteLine("\nMarnie bursts into tears. Marlon moves to comfort her.");
            Console.WriteLine("Marnie > Yes, I did it. I wanted to tell everyone about us, but he wouldn't.");
            Console.WriteLine("Marnie > I said if he was ashamed of me then we should break up, and he got angry and went to hit me with that damed statue.");
            Console.WriteLine("Marnie > I grabbed it off him and... well, you know. It was self defense.");
            Console.WriteLine("Everyone's gone quiet.");
            Console.WriteLine("Gus > It's ok, Marnie. We had no idea he was like that, or we would have put a stop to it.");
            Console.WriteLine("Marnie sobs.");
            Console.WriteLine("Shane... look after the animals for me.");
        }

        public static void KentIsTheMurderer()
        {
            Console.WriteLine("\nJodi is the first to react, making a noise of disbelief. Kent stares at you calmly, before nodding and bowing his head.");
            Console.WriteLine("Kent > I knew the election was coming up, and I really thought I could make a difference.");
            Console.WriteLine("Kent > Lewis was Mayor of Pelican Town forever, and I figured there was no chance of me winning while he was still around.");
            Console.WriteLine("Kent > *sigh* I just wanted to feel useful again...");
            Console.WriteLine("He turns to Jodi.");
            Console.WriteLine("Kent > I'm sorry, hunny. I love you.");
        }

        public void PlayerGuessedWrong(string AccusedMurderer)
        {
            Console.WriteLine($"\n{AccusedMurderer} > Uh, what? You think I did it?");
            Console.WriteLine($"Me > I'm afraid the evidence does suggest so, yes.");
            Console.WriteLine($"{SaveData.TheMurderer} > I can't believe it, {AccusedMurderer}. How could you?");
            Console.WriteLine($"{AccusedMurderer} > I didn't! I don't know what you think has gone on here, Detective, but you've got the wrong person.");
            Console.WriteLine($"Me > Well, we can discuss it all back at the station. Let's go.");
        }

        public void AnnounceNewMayor(string AccusedMurderer)
        {
            Console.WriteLine($"\nBefore you lead {AccusedMurderer} away, the Governor stops you.");
            Console.WriteLine("Govenor > Wait - we have to announce the results first.");
            Console.WriteLine("He pulls out a piece of paper.");
            Console.WriteLine("Govenor > Firstly, thank you to all of you for turning out to vote, and to our three candidates.");
            Console.WriteLine("I am happy to announce that the new Mayor of Pelican Town is...\n");
            Console.WriteLine("Enter > Continue\n");
            Console.ReadKey();
            Console.WriteLine($"...{SaveData.NewMayor}!\n");

            EndGame();
        }

        void EndGame()
        {
            if (SaveData.AccusedMurderer == SaveData.TheMurderer) WinGame();
            else LoseGame();
            Console.WriteLine("\nThank you for playing.\n");
            Console.WriteLine("Stardew Valley: A Murder Mystery developed by Matthew Kennedy, based on Stardew Valley by Concerned Ape.");
            Console.WriteLine("Special Thanks to Benjamin for all his help.");
            Console.WriteLine("For Mel <3\n");
        }

        static void WinGame()
        {
            Console.WriteLine("Congratulations, you correctly identified the Murderer!");
            Console.WriteLine("YOU WIN");
        }
        static void LoseGame()
        {
            Console.WriteLine("You did not correctly identify the Murderer.");
            Console.WriteLine("GAME OVER");
            Console.WriteLine("BETTER LUCK NEXT TIME");
        }
    }
}
