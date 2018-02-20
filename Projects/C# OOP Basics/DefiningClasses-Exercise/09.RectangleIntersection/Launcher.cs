using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var rectangles = SetRectangles(int.Parse(firstLine[0]));
        CheckIntersections(int.Parse(firstLine[1]), rectangles);
    }

    private static void CheckIntersections(int numberOfIntersectionChecks, Queue<Rectangle> rectangles)
    {
        for (int i = 0; i < numberOfIntersectionChecks; i++)
        {
            var pair = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var firstRect = rectangles.Where(r => r.Id == pair[0]).FirstOrDefault();
            var secondRect = rectangles.Where(r => r.Id == pair[1]).FirstOrDefault();
            Console.WriteLine(firstRect.IsThereIntersection(secondRect) ? "true" : "false");
        }
    }

    private static Queue<Rectangle> SetRectangles(int numberOfRectangles)
    {
        var rectangles = new Queue<Rectangle>(numberOfRectangles);

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            rectangles.Enqueue(new Rectangle(input[0], double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4])));
        }
        return rectangles;
        
    }
}

