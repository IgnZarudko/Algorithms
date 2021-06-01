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

        public (int minWeight, List<int> minRoute) Search()
        {
            List<int> previousRoute = null;
            var currentRoute = RandomRoute();
            
            int minWeight = 0;
            List<int> minRoute = null;
            
            while (previousRoute != currentRoute)
            {
                previousRoute = currentRoute;
                (minWeight, minRoute) = SearchOnce(currentRoute);
                currentRoute = minRoute;
                Console.WriteLine($"Weight: {minWeight} \nRoute: {RouteToString(currentRoute)}");
            }

            return (minWeight, minRoute);
        }

        private (int minWeight, List<int> minRoute) SearchOnce(List<int> startRoute)
        {
            var minRoute = startRoute;
            var minWeight = GetRouteWeight(minRoute);
            
            var neighborhood = GetNeighborhood(minRoute);
            
            foreach (var neighbor in neighborhood)
            {
                var neighborWeight = GetRouteWeight(neighbor);

                if (neighborWeight < minWeight)
                {
                    minWeight = neighborWeight;
                    minRoute = neighbor;
                }
            }

            return (minWeight, minRoute);
        }

        private static string RouteToString(List<int> route)
        {
            var builder = new StringBuilder(" ");
            foreach (var vertex in route)
                builder.Append(vertex).Append(" -> ");

            return builder.Append(route[0]).ToString();
        }

        private int GetRouteWeight(List<int> route)
        {
            int weight = 0;
            int n = route.Count;
            
            for (var i = 0; i < n; i++)
            {
                weight += _weights[route[i % n]][route[(i + 1) % n]];
            }

            return weight;
        }
        
        private static List<List<int>> GetNeighborhood(List<int> route)
        {
            var neighborhood = new List<List<int>>();

            for (var i = 0; i < route.Count - 2; i++)
            {
                for (var j = i + 2; j < route.Count; j++)
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