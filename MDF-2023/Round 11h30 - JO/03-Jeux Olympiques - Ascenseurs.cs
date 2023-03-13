using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Jeux Olympiques - Ascenseurs

Jacques est en retard pour la cérémonie de fermeture des JO, il n'aura pas le temps d'arriver à l'heure à la cérémonie. Pour cette raison, il compte regarder la cérémonie de fermeture depuis le toit de son hotel.

L'hôtel est un peu particulier : Il a N étages et M ascenseurs. Le i-ème ascenseur permet d'aller à tous les étages entre L_i et R_i. Il est actuellement dans sa chambre à l'étage E, peut-il accéder au toit situé au N-ème étage ?
Données
Entrée

Ligne 1 : Trois entiers N (1 <= N <= 10^5), M (1 <= M <= 10^5) et E (1 <= E < N). N représente le nombre d'étages, M le nombre d'ascenseurs et E l'étage où est situé Jacques. Les M lignes suivantes : Deux entiers L_i et R_i par ligne compris entre 1 et N (L_i <= R_i), donnant la plage d'étages auquel peut accéder le ième ascenseur.
Sortie

Une seule ligne : YES s'il est possible d'aller de l'étage E à l'étage N, NO sinon
Exemple

Pour l'entrée :

3 2 1
1 2
2 3

La sortie est :

YES

En effet, il peut utiliser le 1er ascenseur pour aller de l'étage 1 à l'étage 2 puis le second pour aller de l'étage 2 à l'étage 3

Pour l'entrée :

3 2 1
1 1
2 3

La sortie attendue est :

NO

En effet, il ne peut pas quitter l'étage 1 
 * Read input from Console
 * Use: Console.WriteLine to output your result to STDOUT.
 * Use: Console.Error.WriteLine to output debugging information to STDERR;
 *       
 * ***/

namespace CSharpContestProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = data[0];
            var m = data[1];
            var start = data[2];
            var elevators = new List<int[]>();
            string line;
            while ((line = Console.ReadLine()) != null) {
                elevators.Add(line.Split().Select(int.Parse).ToArray());
            }
            var lastElevator = new [] {-1, -1};
            foreach(var elevator in elevators.OrderBy(e => e[0]).ThenBy(e => e[1])) {
                if (lastElevator[1] < elevator[0])
                    lastElevator = elevator; //cannot merge so replace
                else if (lastElevator[1] < elevator[1])
                    lastElevator[1] = elevator[1]; //merge
            }
            if (lastElevator[1]==n && lastElevator[0]<=start) 
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
