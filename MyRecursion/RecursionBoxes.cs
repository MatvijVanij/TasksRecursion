using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecursion
{
    public class Node
    {
        public static List<int> Boxes { get; set; }
        public int EmptyPlace { get; set; }
        public List<int> CurrentBoxes { get; set; }
        public List<Node> Next { get; set; }

        public Node(int emptyPlase, List<int> currentBoxes = null)
        {
            EmptyPlace = emptyPlase;
            Next = new List<Node>();
            if (currentBoxes is null)
            {
                CurrentBoxes = new List<int>();
            }
            else
            {
                CurrentBoxes = currentBoxes;
            }
        }

        public void CreateGraph()
        {
            foreach (int box in Boxes)
            {
                if (EmptyPlace >= box)
                {
                    List<int> tmp = new List<int>(CurrentBoxes);
                    tmp.Add(box);
                    Node node = new Node(EmptyPlace - box, tmp);
                    Next.Add(node);
                    node.CreateGraph();
                }

            }
        }
        public void WriteAllLeaves()
        {
            if (Next.Count == 0)
            {
                foreach (int b in CurrentBoxes)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (Node n in Next)
                {
                    n.WriteAllLeaves();
                }
            }
        }

        public ReturnModel FindLeafWithMinEmptyPlace()
        {
            if (Next.Count == 0)
            {
                return new ReturnModel(EmptyPlace, CurrentBoxes);
            }
            else
            {
                List<ReturnModel> returnModels = new List<ReturnModel>();
                foreach (Node n in Next)
                {
                    returnModels.Add(n.FindLeafWithMinEmptyPlace());
                }

                ReturnModel min = returnModels[0];
                foreach (ReturnModel r in returnModels)
                {
                    if (min.EmptyPlace > r.EmptyPlace)
                    {
                        min = r;
                    }
                    else if ((min.EmptyPlace == r.EmptyPlace) && (min.CurrentBoxes.Count > r.CurrentBoxes.Count))
                    {
                        min = r;
                    }
                }
                return min;
            }
        }
    }
    public class ReturnModel
    {
        public int EmptyPlace { get; set; }
        public List<int> CurrentBoxes { get; set; }
        public ReturnModel(int emptyPlase, List<int> currentBoxes)
        {
            EmptyPlace = emptyPlase;
            CurrentBoxes = new List<int>(currentBoxes);
        }
    }

}



