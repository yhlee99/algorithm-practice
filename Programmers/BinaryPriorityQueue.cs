using System;

public class BinaryPriorityQueue 
{
    public class Node
    {
        public int number;

        public Node parentNode;

        public Node leftNode;
        public Node rightNode;

        public Node(int number)
        {
            this.number = number;
        }

        public void ClearNode()
        {
            if (parentNode != null)
            {
                if (number < parentNode.number) 
                {
                    if (this.rightNode != null)
                    {
                        parentNode.leftNode = this.rightNode;
                    }
                    else
                    {
                        parentNode.leftNode = null;
                    }
                }
                else
                {
                    if (this.leftNode != null)
                    {
                        parentNode.rightNode = this.leftNode;
                    }
                    else
                    {
                        parentNode.rightNode = null;
                    }
                }
            }
        }
    }

    Node topNode;

    public int[] solution(string[] operations) 
    {
        foreach (string operation in operations)
        {
            switch (operation)
            {
                case "D 1":
                    DeleteMaxNode();
                    break;
                case "D -1":
                    DeleteMinNode();
                    break;
                default:
                    string numText = operation.Replace("I ", string.Empty);
                    InsertNode(new Node(Int32.Parse(numText)));
                    break;
            }
        }

        return GetMinMaxNode();
    }

    public int[] GetMinMaxNode()
    {
        if (topNode == null)
        {
            return new int[2] {0, 0};
        }

        int maxValue, minValue;

        Node nowNode = topNode;

        while (true)
        {
            if (nowNode.rightNode == null)
            {
                maxValue = nowNode.number;
                break;
            }
            else
            {
                nowNode = nowNode.rightNode;
            }
        }

        nowNode = topNode;

        while (true)
        {
            if (nowNode.leftNode == null)
            {
                minValue = nowNode.number;
                break;
            }
            else
            {
                nowNode = nowNode.leftNode;
            }
        }

        return new int[2] {maxValue, minValue};
    }

    public void DeleteMaxNode()
    {
        if (topNode == null)
        {
            return;
        }

        Node nowNode = topNode;

        while (true)
        {
            if (nowNode.rightNode == null)
            {
                if (nowNode.parentNode != null)
                {
                    nowNode.ClearNode();
                }
                else
                {
                    topNode = null;
                }
                break;
            }
            else
            {
                nowNode = nowNode.rightNode;
            }
        }
    }

    public void DeleteMinNode()
    {
        if (topNode == null)
        {
            return;
        }

        Node nowNode = topNode;

        while (true)
        {
            if (nowNode.leftNode == null)
            {
                if (nowNode.parentNode != null)
                {
                    nowNode.ClearNode();
                }
                else
                {
                    topNode = null;
                }
                break;
            }
            else
            {
                nowNode = nowNode.leftNode;
            }
        }
    }

    public void InsertNode(Node node)
    {
        if (topNode == null)
        {
            topNode = node;
        }
        else
        {
            Node nowNode = topNode;

            while (true)
            {
                if (node.number < nowNode.number)
                {
                    if (nowNode.leftNode == null)
                    {
                        nowNode.leftNode = node;
                        node.parentNode = nowNode;

                        break;
                    }
                    else
                    {
                        nowNode = nowNode.leftNode;
                    }
                }
                else
                {
                    if (nowNode.rightNode == null)
                    {
                        nowNode.rightNode = node;
                        node.parentNode = nowNode;

                        break;
                    }
                    else
                    {
                        nowNode = nowNode.rightNode;
                    }
                }
            }
        }
    }
}