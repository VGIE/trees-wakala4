
using System;
using Lists;

namespace Trees
{
    public class TreeNode<T>
    {
        private T Value;
        //TODO #1: Declare a member variable called "Children" as a list of TreeNode<T> objects
        private List<TreeNode<T>> Children;
        

        public TreeNode(T value)
        {
            //TODO #2: Initialize member variables/attributes
            this.Value = value;

            this.Children = new List<TreeNode<T>>();
        }

        public string ToString(int depth, int index)
        {
            //TODO #3: Uncomment the code below
            
            string output = null;
            string leftSpace = null;
            for (int i = 0; i < depth; i++) leftSpace += " ";
            if (leftSpace != null) leftSpace += "->";

            output += $"{leftSpace}[{Value}]\n";

            for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
            {
               TreeNode<T> child = Children.Get(childIndex);
               output += child.ToString(depth + 1, childIndex);
            }
            return output;
        }

        public TreeNode<T> Add(T value)
        {
            //TODO #4: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
            TreeNode<T> addNode = new TreeNode<T>(value);
            this.Children.Add(addNode);
            return addNode;
            
        }

        public int Count()
        {
            //TODO #5: Return the total number of elements in this tree
            int numElements = 1;
            for(int i = 0; i<Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                numElements += child.Count();
            }
            return numElements;
            
        }

        public int Height()
        {
            //TODO #6: Return the height of this tree
            if (Children.Count() == 0)
            {
                return 0;
            }
            int maxHeight = -1;
            for(int i = 0; i<Children.Count(); i++)
            {
                int childHeight = Children.Get(i).Height();
                if (childHeight > maxHeight)
                {
                    maxHeight = childHeight;
                }
            }
            return maxHeight + 1;
            
        }


        //Problema en la recursividad del Remove o el Find, no se cual de los dos.

        public void Remove(T value)
        {
            //TODO #7: Remove the child node that has Value=value. Apply recursively
            int i = 0;
            while (i < Children.Count())
            {
                TreeNode<T> child = Children.Get(i);
                if (child.Value.Equals(value))
                {
                    Children.Remove(i);
                }
                else
                {
                    child.Remove(value);
                    i++;
                }
            }
        }

        public TreeNode<T> Find(T value)
        {
            //TODO #8: Return the node that contains this value (it might be this node or a child). Apply recursively
            if (this.Value.Equals(value))
            {
            return this; 
            }
            
            for (int i = 0; i < Children.Count(); i++)
            {
                TreeNode<T> child = Children.Get(i);
                TreeNode<T> foundNode = child.Find(value);

                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }


        public void Remove(TreeNode<T> node)
        {
            //TODO #9: Same as #6, but this method is given the specific node to remove, not the value
            int i = 0;
            while (i < Children.Count())
            {
                TreeNode<T> child = Children.Get(i);
                if (child == node)
                {
                    Children.Remove(i);
                }
                else
                {
                    child.Remove(node);
                    i++;
                }
            }   
        }
    }
}