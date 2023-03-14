using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Basket - Au Buzzer

Vous êtes embauché·e en cours de match pour devenir l'entraîneur d'une équipe de basket. Vous ne connaissez rien au sport, mais on vous a quand même dit que le nombre maximum de points marqués en mettant un panier est de 3.

C'est le dernier temps mort, et vous décidez de motiver vos joueurs en leur disant de combien de paniers ils ont besoin pour passer devant l'équipe adverse. Vous connaissez le score, qui est affiché sur un énorme panneau électronique au milieu du terrain.

Combien la première équipe doit-elle marquer de paniers à 3 points au minimum pour obtenir strictement plus de points que la deuxième équipe ?
Données
Entrée

Le score de la première, puis de la deuxième équipe, séparés par un tiret. Chaque équipe a marqué moins de 1000 points.
Sortie

Le nombre minimum de paniers à 3 points que la première équipe doit marquer pour avoir strictement plus de points que la deuxième équipe.
Exemple

Pour un score de :

89-104

La nombre minimum est :

6

Pour un score de:

13-9

Le nombre minimum est :

0


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
            var scores = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            if (scores[0]>scores[1]) {
                Console.WriteLine(0);
            } else {
                var scoreDifference = Math.Max(scores[1] - scores[0],0);
                var missingBaskets = scoreDifference / 3;
                missingBaskets++; //to be strictly greater
                Console.WriteLine(missingBaskets);
            }
        }
    }
}
