using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Jeux Olympiques - Ya pu d'saisons

À cause du dérèglement climatique, au grand malheur de Vivaldi, il n’y a plus 4 saisons mais N saisons différentes. La i-ème saison dure J_i jours, naturellement, après la fin de la N-ème saison, on revient à la premiere saison.

On est actuellement au premier jour de la première saison. Vous travaillez pour la mairie de Paris qui souhaite organiser les JO au K-ème jour en commencant aujourd'hui. Vous voulez savoir quelle sera la saison ce jour là afin de voir si il est possible d'y organiser les JO.
Données
Entrée

Ligne 1 : Un entier N ( 1 <= N <= 10^5 ), le nombre de saisons.

Ligne 2 : Un entier K (1 <= K <= 10^9), le jour dont vous voulez connaitre la saison.

Ligne 3 : N entiers, où le i-ème entier est le nombre de jours dans la i-ème saison
Sortie

Un seul entier : Le numéro de la saison au bout de K jours.
Exemple

Pour l'entrée :

5 
17
10 20 5 18 12

La saison est :

2

En effet, la première saison dure du jour 1 au jour 10, tandis que la deuxième dure du jour 11 au jours 30. Donc le 17ème jour est lors de la deuxième saison.

Pour l'entrée :

5 
237
10 20 5 18 12

La saison est :

4

En effet, le 237-ème jour est au 7ème jour de la 4ème saison.


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
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var seasons = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var fullYear = seasons.Sum(x => x);
            var season=0;
            k = k % fullYear;
            
            while(true) {
                k-=seasons[season];
                if (k<=0) break;
                season = (season+1) % n;
            }
            
            Console.WriteLine(season+1); //we count seasons starting at 1!
        }
    }
}
