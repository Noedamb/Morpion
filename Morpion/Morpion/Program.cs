using System;
using System.Security.Policy;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion() // (int j, int k)
        {
            for (var row = 0; row  < grille.GetLength(0); row++) 
            {
                Console.Write("\n|====|====|====|\n");
                Console.Write("|");
                //2eme dimension
                for (var col = 0; col < grille.GetLength(1); col++)
                {
                    Console.Write(" -- ");
                    Console.Write("|");
                }  
            }
            Console.Write("\n|====|====|====|\n");
        }
        
	        /* Fonction permettant de changer dans le tableau qu'elle est le joueur qui à jouer
	        Bien vérifier que le joueur ne sortpas du tableau et que la position n'est pas déjà jouée */
        public static bool AJouer(int j, int k, int joueur)
        {		
        	if (j < 0 | j >= grille.GetLength(0) | k < 0 | k >= grille.GetLength(1)) // j = row && k = col 
            {
                Console.WriteLine("Position invalide.");
                return false;
            }
            if (grille[j, k] != 10) 
            {
                Console.WriteLine("Position est déjà occupée.");
                return false;
            }
            grille[j, k] = joueur;
            return true;
        }

        // Fonction permettant de vérifier
        // si un joueur à gagner
        public static bool Gagner(int l, int c, int joueur)
        {
			// Vérifie la ligne si le joueur a complété 3 
            for (int j = 0; j < grille.GetLength(0); j++)
            {
                if (grille[j, j] != joueur)
                    break;
                if (j == grille.GetLength(0) - 1)
                    return true;
            }
            // Vérifie la ligne si le joueur a complété 3 
            for (int k =0; k < grille.GetLength(1); k++)
            {
            	if (grille[k,k] != joueur)
            		break;
            	if (k == grille.GetLength(1) - 1)
            		return false;		
            }
            // Vérifie le diagonale


            // Vérifie le diagonale opposé 
            return true;
        }
 
        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

            int essais = 0;    // compteur d'essais
	        int joueur = 1 ;   // 1 pour la premier joueur, 2 pour le second
	        int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur à gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaité est disponible
            Console.WriteLine("Bienvenue dans la partie Morpion");
            Console.WriteLine("le joueur 1 joue avec un [X] et le joueur 2 joue avec un [O]");
	        //--- initialisation de la grille ---
            // On met chaque valeur du tableau à 10
	        for (j=0; j < grille.GetLength(0); j++)
		        for (k=0; k < grille.GetLength(1); k++)
			        grille[j,k] = 10;
					while(!gagner && essais != 9)
					{
	                AfficherMorpion();


						// A compléter 
						try
						{
							Console.WriteLine("Ligne   =    ");
							Console.WriteLine("Colonne =    ");
							// Peut changer en fonction de comment vous avez fait votre tableau.
							Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 9); // Permet de manipuler le curseur dans la fenêtre 
							l = int.Parse(Console.ReadLine()) - 1; 
							// Peut changer en fonction de comment vous avez fait votre tableau.
							Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
							c = int.Parse(Console.ReadLine()) - 1;

							// A compléter 

						}
						catch (Exception e)
						{
							Console.WriteLine(e.ToString());
						}

						// Changement de joueur
						// A compléter 

					}; // Fin TQ

            // Fin de la partie
            // A compléter 
// n'oublie pas de commenter les lignes de commande
            Console.ReadKey();
    }
 }
    
}
