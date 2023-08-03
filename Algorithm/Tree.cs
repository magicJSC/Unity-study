using System;
using System.Collections;

namespace Exercise
{
    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }
    class Program
    {
        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }
            }
            return root;
        }

        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);

            foreach (TreeNode<string> child in root.Children)
            {
                PrintTree(child);
            }
        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;

            foreach (TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child) + 1;
                height = Math.Max(height, newHeight);
            }

            return height;
        }
        static void Main(string[] args)
        {
            TreeNode<string> root = MakeTree();

            Console.WriteLine(GetHeight(root));
        }
    }
}