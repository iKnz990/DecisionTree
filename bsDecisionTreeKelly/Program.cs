using System;
/***************************************************************
*Name : Decision Tree
* Author: Alexander Kelly
* Created : 3/ 25 / 2023
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 11
* IDE: Visual Studio 2019
* Copyright : Cannot copyright Academic Material.
* Description : Yes no... there's really not a maybe.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.*/
namespace bsDecisionTreeKelly 
{
    class Node // O(1)
    {
        public string Question { get; set; }
        public Node YesNode { get; set; }
        public Node NoNode { get; set; }

        public virtual void Traverse()
        {
            Console.Write(Question);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                YesNode.Traverse();
            }
            else
            {
                NoNode.Traverse();
            }
        }
    }

    class LeafNode : Node
    {
        public string Result { get; set; }

        public override void Traverse()
        {
            Console.WriteLine(Result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create the root node of the decision tree
            Node root = new Node
            {
                Question = "Is the course required for your major?",
                // If the answer is "yes", take the course
                YesNode = new LeafNode { Result = "Take the course." },
                // If the answer is "no", ask another question
                NoNode = new Node
                {
                    Question = "Is the course relevant to your interests or career goals?",
                    // If the answer is "yes", ask another question
                    YesNode = new Node
                    {
                        Question = "Do you have the prerequisites for the course?",
                        // If the answer is "yes", take the course
                        YesNode = new LeafNode { Result = "Take the course." },
                        // If the answer is "no", don't take the course
                        NoNode = new LeafNode { Result = "Don't take the course." }
                    },
                    // If the answer is "no", ask another question
                    NoNode = new Node
                    {
                        Question = "Have you taken any similar courses before?",
                        // If the answer is "yes", ask another question
                        YesNode = new Node
                        {
                            Question = "Did you enjoy similar courses?",
                            // If the answer is "yes", take the course
                            YesNode = new LeafNode { Result = "Take the course." },
                            // If the answer is "no", don't take the course
                            NoNode = new LeafNode { Result = "Don't take the course." }
                        },
                        // If the answer is "no", ask another question
                        NoNode = new Node
                        {
                            Question = "Do you have space in your schedule for the course?",
                            // If the answer is "yes", take the course
                            YesNode = new LeafNode { Result = "Take the course." },
                            // If the answer is "no", don't take the course
                            NoNode = new LeafNode { Result = "Don't take the course." }
                        }
                    }
                }
            };

            // Start traversing the tree from the root node
            root.Traverse();
        }
    }
}
