using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Tricheurs

Vous organisez le Master Dev France dans la ville de Paris et vous souhaitez cacher le chèque du vainqueur dans un immeuble de sorte à ce qu'aucun tricheur ne puisse arriver à cet immeuble avant le vainqueur.

Plus précisément, la ville de Paris est composée de N bâtiments et M routes bidirectionnelles, il est possible de se déplacer entre n'importe quelle paire de bâtiments en empruntant les routes. Le gagnant est actuellement situé dans le bâtiment numéro 1, tandis que les T tricheurs sont situés aux bâtiments u_1, u_2, ..., u_T. Vous devez renvoyer la liste triée de tous les bâtiments où le vainqueur peut arriver strictement avant les tricheurs.
Données
Entrée

Ligne 1 : Trois entiers N (1 <= N <= 10^4) le nombre de bâtiments, M (1 <= M <= 2 * 10^4) le nombre de routes, T (1 <= T <= N) le nombre de tricheurs.

Ligne 2 : T entiers distincts entre 2 et N : Les positions initiales des tricheurs.

Les M lignes suivantes : deux entiers u et v, indiquant qu'il y a une route entre u et v (1 <= u < v <= N).
Sortie

S'il y a K bâtiments où le vainqueur peut arriver avant les tricheurs, vous devez renvoyer K entiers triés sur une seule ligne : la liste des bâtiments en question.
Exemple

Pour l'entrée :

7 6 2
5 6
1 2 
1 3
2 4
4 5
3 6
3 7

La réponse est :

1 2

Ce sont effectivement les seuls sommets où le vainqueur peut arriver strictement avec tous les tricheurs.

 


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
            var data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = data[0];
            var m = data[1];
            var t = data[2];
            var cheaters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var winner = 1;
            var graph = Enumerable.Range(0,n+1).Select(_ => new List<int>()).ToArray();
            
            string line;
            while ((line = Console.ReadLine()) != null) {
                data = line.Split(' ').Select(int.Parse).ToArray();
                graph[data[0]].Add(data[1]);
                graph[data[1]].Add(data[0]);
            }
            
            //time for cheaters to get there
            var timeToGetThere = new int[n+1];
            var step=0;
            var seen = new HashSet<int>();
            var todo = cheaters.ToList();
            while(todo.Any()) {
                var next = new List<int>();
                step++;
                foreach(var current in todo) {
                    foreach(var neighbor in graph[current]) {
                        if (seen.Contains(neighbor)) continue;
                        seen.Add(neighbor);
                        timeToGetThere[neighbor]=step;
                        next.Add(neighbor);
                    }
                }
                todo = next;
            }
            
            //now, let's check which cells we can reach before them
            var answer = new List<int>{ winner };
            seen.Clear();
            seen.Add(winner);
            step=0;
            todo.Add(winner);
            while(todo.Any()) {
                var next = new List<int>();
                step++;
                foreach(var current in todo) {
                    foreach(var neighbor in graph[current]) {
                        if (seen.Contains(neighbor)) continue;
                        if (timeToGetThere[neighbor]<=step) continue;
                        seen.Add(neighbor);
                        answer.Add(neighbor);
                        next.Add(neighbor);
                    }
                }
                todo = next;
            }

            Console.WriteLine(string.Join(" ", answer.OrderBy(x => x)));
        }
    }
}
