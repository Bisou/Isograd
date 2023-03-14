using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Poubelles - La plus belle des poubelles

Le moment que vous attendiez si longtemps est enfin arrivé ! Vous venez d'emmenager dans votre nouvel appartement, et vous allez enfin pouvoir prendre la décision la plus importante et palpitante de votre vie : acheter une poubelle.

Mais ça ne se fait pas si facilement : il faut une poubelle assez volumineuse, et la plus jolie possible, bien sûr !

Vous avez à disposition le volume et la beauté des différentes poubelles disponibles, et vous devez trouver la plus belle à avoir un volume d'au moins 20 litres. Quelle beauté aura la poubelle choisie ?
Données
Entrée

Ligne 1 : un entier N compris entre 1 et 100, représentant le nombre de poubelles disponibles.

N lignes suivantes : une poubelle par ligne. Chaque poubelle est décrite par deux entiers, séparés par une espace. Le premier représente le volume en litres de la poubelles, le deuxième sa beauté.
Sortie

La beauté maximum d'une poubelle suffisament volumineuse (au moins 20 litres). On vous garantit qu'il y aura toujours au moins une poubelle d'au moins 20 litres.
Exemple

Pour l'entrée :

4
30 25
20 40
10 50
20 30

La sortie attendue est :

40

En effet, la plus jolie des poubelles parmi celles qui ont un volume d'au moins 20 litres est celle qui a une beauté de 40. 
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
            string line;
            var maxBeauty=0;
            while ((line = Console.ReadLine()) != null) {
                var data=line.Split(' ');
                if (int.Parse(data[0])>=20)
                    maxBeauty = Math.Max(maxBeauty, int.Parse(data[1]));
            }

            Console.WriteLine(maxBeauty);
        }
    }
}
