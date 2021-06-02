using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalSearch
{
    public class SalesmenSolver
    {
        private static readonly Random Random = new();

        private readonly List<List<int>> _weights;
        private readonly List<int> _vertices;

        public SalesmenSolver(List<List<int>> weights)
        {
            _weights = weights;
            _vertices = new List<int>();
            for (var i = 0; i < weights.Count; i++)
                _vertices.Add(i);
        }

        private List<int> RandomRoute() => _vertices.OrderBy(Random.Next).ToList();

        public (int minimalWeight, List<int> minimalRoute) Search()
        {
            List<int> previousRoute = null;
            var currentRoute = RandomRoute();
            
            int minimalWeight = 0;
            List<int> minimalRoute = null;

            Console.WriteLine("-------------");
            Console.WriteLine($"Start Route: {RouteString(currentRoute)}");
            Console.WriteLine($"Its Weight: {RouteWeight(currentRoute)}");
            
            while (previousRoute != currentRoute)
            {
                previousRoute = currentRoute;
                (minimalWeight, minimalRoute) = SearchOnce(currentRoute);
                currentRoute = minimalRoute;
            }

            return (minimalWeight, minimalRoute);
        }

        private (int minimalWeight, List<int> minimalRoute) SearchOnce(List<int> startRoute)
        {
            var minimalRoute = startRoute;
            var minimalWeight = RouteWeight(minimalRoute);
            
            var neighborhood = Neighborhood(minimalRoute);
            
            foreach (var neighbor in neighborhood)
            {
                var neighborWeight = RouteWeight(neighbor);

                if (neighborWeight < minimalWeight)
                {
                    minimalWeight = neighborWeight;
                    minimalRoute = neighbor;
                }
            }
            
            Console.WriteLine("-------------");
            Console.WriteLine($"New minimal Route: {RouteString(minimalRoute)}");
            Console.WriteLine($"Its Weight: {minimalWeight}");

            return (minimalWeight, minimalRoute);
        }

        private static string RouteString(List<int> route)
        {
            var builder = new StringBuilder(" ");
            foreach (int vertex in route)
                builder.Append(vertex).Append(" -> ");

            return builder.Append(route[0]).ToString();
        }

        private int RouteWeight(List<int> route)
        {
            int weight = 0;
            int n = route.Count;
            
            for (int i = 0; i < n; i++)
            {
                weight += _weights[route[i % n]][route[(i + 1) % n]];
            }

            return weight;
        }
        
        private static List<List<int>> Neighborhood(List<int> route)
        {
            var neighborhood = new List<List<int>>();

            for (int i = 0; i < route.Count - 2; i++)
            {
                for (int j = i + 2; j < route.Count; j++)
                {
                    var neighbor = new List<int>(route);
                    (neighbor[i], neighbor[j]) = (neighbor[j], neighbor[i]);
                    neighborhood.Add(neighbor);
                }
            }

            return neighborhood;
        }
    }
}