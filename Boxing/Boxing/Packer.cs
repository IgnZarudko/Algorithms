using System;
using System.Collections.Generic;

namespace Boxing
{
    public class Packer
    {
        public static List<Box> PackNextFit(List<double> parts)
        {
            List<Box> boxes = new List<Box>{new()};
            foreach (double part in parts) 
            {
                if (!boxes[^1].Put(part))
                {
                    boxes.Add(new Box());
                    boxes[^1].Put(part);
                }
            }

            return boxes;
        }

        public static List<Box> PackFirstFit(List<double> parts)
        {
            List<Box> boxes = new List<Box> {new()};

            foreach (double part in parts)
            {
                bool isPutInExistingBox = false;
                foreach (Box box in boxes)
                { 
                    if (box.Put(part))
                    {
                        isPutInExistingBox = true;
                        break; 
                    }
                }

                if (!isPutInExistingBox)
                {
                    boxes.Add(new Box()); 
                    boxes[^1].Put(part);
                }
            }

            return boxes;
        }

        public static List<Box> PackBestFit(List<double> parts)
        {
            List<Box> boxes = new List<Box> {new()};

            foreach (double part in parts)
            {
                double spaceOfBestFit = Double.MaxValue;
                int indexOfBestFit = -1;
                for (int i = 0; i < boxes.Count; i++)
                {
                    double howMuchSpaceWillBeAfterInsert = boxes[i].AvailableSpace - part;
                    if (howMuchSpaceWillBeAfterInsert >= 0 && spaceOfBestFit > howMuchSpaceWillBeAfterInsert)
                    {
                        spaceOfBestFit = howMuchSpaceWillBeAfterInsert;
                        indexOfBestFit = i;
                    }
                }

                if (indexOfBestFit != -1)
                {
                    boxes[indexOfBestFit].Put(part);
                }
                else
                {
                    boxes.Add(new Box());
                    boxes[^1].Put(part);
                }
            }

            return boxes;
        }

        public static List<Box> PackFirstFitDecrease(List<double> parts)
        {
            parts.Sort();
            parts.Reverse();
            return PackFirstFit(parts);
        }
    }
}