// See https://aka.ms/new-console-template for more information

var routes = new int[2][] { new int[] { 1, 2, 7 }, new int[] { 3, 6, 7 } };
int source = 1;
int target = 6;
Solution s = new Solution();
var answer = s.NumBusesToDestination(routes, source, target); 
Console.WriteLine(answer);

public class Solution
{
  public int NumBusesToDestination(int[][] routes, int source, int target)
  {
    // if source == target, return 0;
    if (source == target) return 0;

    // Create Dictionary, key = bus stop, values = buses stop at this stop.
    var map = new Dictionary<int, HashSet<int>>();
    int ROW = routes.Length;
    int COLUMN = routes[0].Length;
    for (int i = 0; i < ROW; i++)
    {
      for (int j = 0; j < COLUMN; j++)
      {
        var stop = routes[i][j];
        if (!map.ContainsKey(stop)) map.Add(stop, new HashSet<int>());
        map[stop].Add(i);
      }
    }
    var visited = new HashSet<int>();
    int count = 0;
    // Create Queue, push the source as to start the BFS
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(source);
    while(queue.Count > 0) 
    {
      count++;
      int size = queue.Count;
      while (size-- > 0)
      {
        var stop = queue.Dequeue();
        // Get all buses stop at this stop
        var buses = map[stop];
        // Loop through for each bus, get all the stops from routes array, and check any stop == target
        foreach (var bus in buses)
        {
          // check the bus is already visited ?
          if (visited.Contains(bus)) continue;
          visited.Add(bus);
          // get the stops at which current bus stops
          var stops = routes[bus];
          foreach(int busStop in stops)
          {
            if (busStop == target) return count;
            queue.Enqueue(busStop);
          }
        }
      }
    }

    return -1;
  }
}